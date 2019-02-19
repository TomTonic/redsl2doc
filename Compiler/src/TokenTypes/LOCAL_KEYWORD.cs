using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class LOCAL_KEYWORD : TokenType
    {
        public override string XMLLabel => "N/A";

        public override void TidyToken(XElement node)
        {
            XElement precedingGlossaryNode = (XElement)node.PreviousNode;
            if (!precedingGlossaryNode.Name.Equals(XName.Get("glossary"))) throw new Exception("Inconsistent XML tree");
            precedingGlossaryNode.SetAttributeValue("mode", "local");
            node.Remove();
        }
    }
}