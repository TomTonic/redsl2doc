using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_WS : DiscardableTokenType
    {
        private static TEXT_WS singleton = new TEXT_WS();
        private TEXT_WS()
        {
        }

        public static TEXT_WS Instance => singleton;
    }
}
