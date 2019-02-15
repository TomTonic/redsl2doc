using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class REQ_DEF_WS : DiscardableTokenType
    {
        private static REQ_DEF_WS singleton = new REQ_DEF_WS();
        private REQ_DEF_WS()
        {
        }

        public static REQ_DEF_WS Instance => singleton;
    }
}
