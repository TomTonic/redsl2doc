using System;
using System.Xml.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using org.ReDSL.Parser;
using org.redsl.Compiler.TokenTypes;
using CommandLine;

namespace org.redsl.Compiler
{
    class MainClass
    {
        public class Options
        {
            [Option('i', "input", Required = true, HelpText = "The name of a text file containing a valid ReDSL document.")]
            public string Input { get; set; }
            [Option('o', "Output", Required = true, HelpText = "The name of a directory where the output files will be written.")]
            public string Output { get; set; }
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        //static string s = "file \"x\" {  §fgh{blll} package \"aa\" \n\r\n\r §1{ blabla bla bla \n\n blo blo \n blu }\n\r\n\r\t§2{}§3{} package \"b\" package \"c\" §asdf{asfrg jgoirjg}  }";
        //static string ex1 = "/Users/tom/git/ReDSL/Compiler/testdata/ex2.redsl";
        public static void Main(string[] args)
        {
            Console.Write(Figgle.FiggleFonts.Standard.Render("ReDSL"));
            CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(opts =>
                {
                    ICharStream stream = CharStreams.fromPath(opts.Input);
                    //ReDSLLexer lexer = new ReDSLLexer(new AntlrInputStream(s));
                    ReDSLLexer lexer = new ReDSLLexer(stream);
                    CommonTokenStream tokens = new CommonTokenStream(lexer);
                    ReDSLParser parser = new ReDSLParser(tokens);
                    ReDSLParser.ParseContext context = parser.parse();
                    ParseTreeWalker walker = new ParseTreeWalker();
                    XMLBuildingListener listener = new XMLBuildingListener();
                    walker.Walk(listener, context);
                    XDocument doc = listener.GetXDocument();
                    if (opts.Verbose) Console.WriteLine();
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    doc = Phase1.TidyTokens(doc); // this will delete superflouos tokens and prepare text tokens for assembly
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    doc = Phase1.ReduceTextNodes(doc); // this will assemble consecutive text and white space tokens for easier text handling afterwards
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    doc = Phase2.TokensToAttributes(doc); // this will move other tokens as attributes to their parents
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    doc = Phase3.PropagateFileAttributes(doc);
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    doc = Phase3.ResolvePackages(doc); // this will assign the package attribute to every requirement declaration
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    doc = Phase3.TidyPackageDeclarations(doc); // this will reorganize all package declarations and move their requirements nodes there
                    if (opts.Verbose) Console.WriteLine(doc.ToString());
                    (new DocGen()).GenerateDocuments(doc, opts.Output);
                }
            );
        }
    }
}
