using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_ID : TokenType
    {
        private static PARAM_ID singleton = new PARAM_ID();
        private PARAM_ID()
        {
        }

        public static PARAM_ID GetInstance() => singleton;

        public override string XMLLabel => "id";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
