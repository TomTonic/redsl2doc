using System;
using System.Xml.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using org.ReDSL.Parser;
using org.redsl.Compiler.TokenTypes;
using CommandLine;
using System.IO;

namespace org.redsl.Compiler
{
    class MainClass
    {
        public class Options
        {
            [Option('i', "input", Required = true, HelpText = "The name of a text file containing a valid ReDSL document, or in case of '-r', the name of the directory to recurse for ReDSL-files.")]
            public string Input { get; set; }
            [Option('o', "output", Required = true, HelpText = "The name of a directory where the output files will be written.")]
            public string Output { get; set; }
            [Option('r', "recurse", Required = false, HelpText = "Recurse input directory for ReDSL files and join them into a single file before processing.")]
            public bool Recurse { get; set; }
            [Option('d', "debug", Required = false, HelpText = "Save intermediate files for debugging purposes.")]
            public bool Debug { get; set; }
        }

        public static void Main(string[] args)
        {
            Console.Write(Figgle.FiggleFonts.Standard.Render("ReDSL"));
            CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(opts =>
            {
                // Generate a unique, temporally ordered prefix for this compiler run
                string runPrefix = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss_fff");
                string inputFile = opts.Input;
                string joinedFile = null;

                // if input is a directory instead of a file, check that the user has set the recurse option
                if (Directory.Exists(opts.Input))
                {
                    if (!opts.Recurse)
                    {
                        Console.Error.WriteLine("Error: Input is a directory, but recurse option is not set. Please use the -r option to enable recursion.");
                        Environment.Exit(1);
                    }
                }
                else if (!File.Exists(opts.Input))
                {
                    Console.Error.WriteLine($"Error: Input file '{opts.Input}' does not exist.");
                    Environment.Exit(1);
                }

                // Stage 00: Join ReDSL files if Recurse is enabled
                if (opts.Recurse)
                {
                    joinedFile = Path.Combine(opts.Output, $"{runPrefix}_00_joined.redsl");
                    MainClass.JoinRedslFiles(opts.Input, joinedFile);
                    inputFile = joinedFile;
                }

                ICharStream stream = CharStreams.fromPath(inputFile);
                ReDSLLexer lexer = new(stream);
                CommonTokenStream tokens = new(lexer);
                ReDSLParser parser = new(tokens);
                ReDSLParser.ParseContext context = parser.parse();
                ParseTreeWalker walker = new();
                XMLBuildingListener listener = new();
                walker.Walk(listener, context);
                XDocument doc = listener.GetXDocument();

                void WriteDoc(string stage, XDocument document)
                {
                    string fileName = $"{runPrefix}_{stage}.xml";
                    string filePath = Path.Combine(opts.Output, fileName);
                    File.WriteAllText(filePath, document.ToString());
                }

                if (opts.Debug) WriteDoc("01_initial", doc);
                doc = Phase1.TidyTokens(doc);
                if (opts.Debug) WriteDoc("02_tidy_tokens", doc);
                doc = Phase1.ReduceTextNodes(doc);
                if (opts.Debug) WriteDoc("03_reduce_text_nodes", doc);
                doc = Phase2.TokensToAttributes(doc);
                if (opts.Debug) WriteDoc("04_tokens_to_attributes", doc);
                doc = Phase3.PropagateFileAttributes(doc);
                if (opts.Debug) WriteDoc("05_propagate_file_attributes", doc);
                doc = Phase3.ResolvePackages(doc);
                if (opts.Debug) WriteDoc("06_resolve_packages", doc);
                doc = Phase3.TidyPackageDeclarations(doc);
                if (opts.Debug) WriteDoc("07_tidy_package_declarations", doc);
                (new DocGen()).GenerateDocuments(doc, opts.Output);

                if (!opts.Debug && joinedFile != null && File.Exists(joinedFile))
                {
                    File.Delete(joinedFile);
                }
            }
            );
        }

        public static void JoinRedslFiles(string inputDirectory, string outputFile)
        {
            var files = Directory.GetFiles(inputDirectory, "*.redsl", SearchOption.AllDirectories);
            using var writer = new StreamWriter(outputFile);
            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var fileName = Path.GetFileName(file).Replace("'", "\\'");
                writer.WriteLine($"file \"{fileName}\" {{" + Environment.NewLine);
                writer.WriteLine(content);
                writer.WriteLine("}" + Environment.NewLine);
            }
        }


    }
}
