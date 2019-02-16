using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class WS : DiscardableTokenType
    {
        private static WS singleton = new WS();
        private WS()
        {
        }

        public static WS Instance => singleton;
    }
}
