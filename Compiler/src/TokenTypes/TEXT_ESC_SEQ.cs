using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_ESC_SEQ : TokenType
    {
        private static TEXT_ESC_SEQ singleton = new TEXT_ESC_SEQ();
        private TEXT_ESC_SEQ()
        {
        }

        public static TEXT_ESC_SEQ Instance => singleton;

        public override string XMLLabel => "text";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
