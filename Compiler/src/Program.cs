using System;
using System.Xml.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using org.ReDSL.Parser;
using org.redsl.Compiler.TokenTypes;

namespace org.redsl.Compiler
{
    class MainClass
    {
        static string s = "file \"x\" {  §fgh{blll} package \"aa\" \n\r\n\r §1{ blabla bla bla \n\n blo blo \n blu }\n\r\n\r\t§2{}§3{} package \"b\" package \"c\" §asdf{asfrg jgoirjg}  }";
        static string ex1 = "/Users/tom/git/ReDSL/Compiler/testdata/ex1.redsl";
        public static void Main(string[] args)
        {
            string filename = ex1;
            ICharStream stream = CharStreams.fromPath(filename);
            //ReDSLLexer lexer = new ReDSLLexer(new AntlrInputStream(s));
            ReDSLLexer lexer = new ReDSLLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ReDSLParser parser = new ReDSLParser(tokens);
            ReDSLParser.ParseContext context = parser.parse();
            ParseTreeWalker walker = new ParseTreeWalker();
            XMLBuildingListener listener = new XMLBuildingListener();
            walker.Walk(listener, context);
            XDocument doc = listener.GetXDocument();
            Console.WriteLine();
            Console.WriteLine(doc.ToString());
            doc = Phase1.TidyTokens(doc);
            Console.WriteLine(doc.ToString());
            doc = Phase1.ReduceTextNodes(doc);
            Console.WriteLine(doc.ToString());
            doc = Phase2.TokensToAttributes(doc);
            Console.WriteLine(doc.ToString());
            doc = Phase3.ResolvePackages(doc);
            Console.WriteLine(doc.ToString());
            doc = Phase3.TidyPackageDeclarations(doc);
            Console.WriteLine(doc.ToString());
        }
    }
}
