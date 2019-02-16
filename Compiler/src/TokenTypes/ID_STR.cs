using System;
using System.Xml.Linq;
using org.redsl.Compiler;

namespace org.redsl.Compiler.TokenTypes
{
    public class ID_STR : TokenType
    {
        private static readonly ID_STR singleton = new ID_STR();
        private ID_STR()
        {
        }

        public static ID_STR Instance => singleton;

        public override string XMLLabel => "id";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            value = Util.TrimQuotes(value);
            node.SetAttributeValue("value", value);
        }
    }
}
