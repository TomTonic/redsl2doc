using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_NUMBER : TokenType
    {
        private static PARAM_NUMBER singleton = new PARAM_NUMBER();
        private PARAM_NUMBER()
        {
        }

        public static PARAM_NUMBER Instance => singleton;

        public override string XMLLabel => "number";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
