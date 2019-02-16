using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_TERM_REF : TokenType
    {
        private static TEXT_TERM_REF singleton = new TEXT_TERM_REF();
        private TEXT_TERM_REF()
        {
        }

        public static TEXT_TERM_REF Instance => singleton;

        public override string XMLLabel => "term";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
