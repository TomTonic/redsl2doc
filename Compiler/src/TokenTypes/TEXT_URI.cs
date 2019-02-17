using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_URI : TokenType
    {
        public override string XMLLabel => "uri";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            node.Name = "uri";
            node.RemoveAttributes();
            node.SetAttributeValue("value", value);
        }
    }
}
