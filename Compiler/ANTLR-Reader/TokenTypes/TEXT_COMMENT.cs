using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_COMMENT : TokenType
    {
        private static TEXT_COMMENT singleton = new TEXT_COMMENT();
        private TEXT_COMMENT()
        {
        }

        public static TEXT_COMMENT Instance => singleton;

        public override string XMLLabel => "comment";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
