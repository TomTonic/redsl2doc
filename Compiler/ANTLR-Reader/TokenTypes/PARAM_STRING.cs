using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_STRING : TokenType
    {
        private static PARAM_STRING singleton = new PARAM_STRING();
        private PARAM_STRING()
        {
        }

        public static PARAM_STRING Instance => singleton;

        public override string XMLLabel => "string";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
