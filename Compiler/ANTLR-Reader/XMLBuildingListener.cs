using System;
using System.Xml.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using org.ReDSL.Parser;
using System.Collections.Generic;


namespace org.redsl.ANTLRReader
{
    public class XMLBuildingListener:ReDSLParserBaseListener
    {
        private Stack<XElement> stack;
        private XDocument doc;

        public XMLBuildingListener()
        {
            this.reset();
        }

        public void reset()
        {
            doc = new XDocument();
            stack = new Stack<XElement>();
        }

        public override void EnterEveryRule([NotNull] ParserRuleContext context)
        {
            Type t = context.GetType(); // antlr calls this method with instances of different classes that carry the name of the rule that has been applied
            string name = t.Name.Substring(0, t.Name.Length - 7); // cut off suffix "Context"
            if (stack.Count == 0)
            {
                // this must be the root node
                XElement root = new XElement("ReDSL");
                root.SetAttributeValue(name: "version", value: "1.0");
                root.SetAttributeValue(name: "gen", value: "0");
                doc.Add(root);
                stack.Push(root);
            }
            else
            {
                XElement parent = stack.Peek();
                XElement child = new XElement(name);
                parent.Add(child);
                stack.Push(child);
            }
        }

        public override void ExitEveryRule([NotNull] ParserRuleContext context)
        {
            stack.Pop();
        }

        public override void VisitErrorNode([NotNull] IErrorNode node)
        {
            AddComment("Error: " + node.ToString());
        }

        public override void VisitTerminal([NotNull] ITerminalNode node)
        {
            IToken symbol = node.Symbol;
            XElement parent = stack.Peek();
            XElement child = new XElement("token");
            child.SetAttributeValue("type", ReDSLParser.DefaultVocabulary.GetSymbolicName(symbol.Type));
            child.SetAttributeValue("value", node.GetText());
            parent.Add(child);
        }

        private void AddComment(string value)
        {
            XElement parent = stack.Peek();
            XComment child = new XComment(value);
            parent.Add(child);
        }

        public XDocument GetXDocument()
        {
            return doc;
        }
    }
}
