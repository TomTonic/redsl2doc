using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_TERM_REF : TokenType
    {
        public override string XMLLabel => "term";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            value = value.Substring(1, value.Length - 2);
            node.Name = "term";
            node.RemoveAttributes();
            node.SetAttributeValue("value", value);
        }
    }
}
