using System;
using System.Xml.Linq;
using org.redsl.Compiler;

namespace org.redsl.Compiler.TokenTypes
{
    public class ID_STR_ESC_SEQ : TokenType
    {
        public override string XMLLabel => "id";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            value = Util.UnescapeBackslashes(value);
            node.SetAttributeValue("type", XMLLabel);
            node.SetAttributeValue("value", value);

        }
    }
}
