using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_CONTENT : TokenType
    {
        private static TEXT_CONTENT singleton = new TEXT_CONTENT();
        private TEXT_CONTENT()
        {
        }

        public static TEXT_CONTENT Instance => singleton;

        public override string XMLLabel => "text";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
