using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class REQ_DEF : TokenType
    {
        private static REQ_DEF singleton = new REQ_DEF();
        private REQ_DEF()
        {
        }

        public static REQ_DEF Instance => singleton;

        public override string XMLLabel => "requirement";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
