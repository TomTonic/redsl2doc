using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_WS : DiscardableTokenType
    {
        private static PARAM_WS singleton = new PARAM_WS();
        private PARAM_WS()
        {
        }

        public static PARAM_WS Instance => singleton;
    }
}
