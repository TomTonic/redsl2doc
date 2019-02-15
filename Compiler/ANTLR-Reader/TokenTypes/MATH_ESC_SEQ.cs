using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class MATH_ESC_SEQ : TokenType
    {
        private static MATH_ESC_SEQ singleton = new MATH_ESC_SEQ();
        private MATH_ESC_SEQ()
        {
        }

        public static MATH_ESC_SEQ Instance => singleton;

        public override string XMLLabel => "math";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            value = Util.UnescapeBackslashes(value);
            node.SetAttributeValue("type", XMLLabel);
            node.SetAttributeValue("value", value);
            throw new Exception("todo");
        }
    }
}
