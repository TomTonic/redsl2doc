using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class ID_STR_ESC_SEQ : TokenType
    {
        private static readonly ID_STR_ESC_SEQ singleton = new ID_STR_ESC_SEQ();
        private ID_STR_ESC_SEQ()
        {
        }

        public static ID_STR_ESC_SEQ Instance => singleton;

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
