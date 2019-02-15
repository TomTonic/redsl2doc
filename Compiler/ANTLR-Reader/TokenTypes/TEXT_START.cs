using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_START : DiscardableTokenType
    {
        private static TEXT_START singleton = new TEXT_START();
        private TEXT_START()
        {
        }

        public static TEXT_START Instance => singleton;
    }
}
