using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_ESC_SEQ : TokenType
    {
        public override string XMLLabel => "text";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            value = Util.UnescapeBackslashes(value);
            node.Name = "text";
            node.RemoveAttributes();
            node.SetAttributeValue("value", value);
        }
    }
}
