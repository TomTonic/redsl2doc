using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_BOOL : TokenType
    {
        private static PARAM_BOOL singleton = new PARAM_BOOL();
        private PARAM_BOOL()
        {
        }

        public static PARAM_BOOL Instance => singleton;

        public override string XMLLabel => "bool";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
