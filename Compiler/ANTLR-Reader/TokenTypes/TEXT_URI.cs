using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_URI : TokenType
    {
        private static TEXT_URI singleton = new TEXT_URI();
        private TEXT_URI()
        {
        }

        public static TEXT_URI Instance => singleton;

        public override string XMLLabel => "uri";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
