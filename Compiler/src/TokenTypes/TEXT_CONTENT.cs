using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_CONTENT : TokenType
    {
        public override string XMLLabel => "text";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            node.Name = "text";
            node.RemoveAttributes();
            node.SetAttributeValue("value", value);
        }
    }
}
