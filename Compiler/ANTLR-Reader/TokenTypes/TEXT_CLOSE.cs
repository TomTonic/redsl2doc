using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_CLOSE : DiscardableTokenType
    {
        private static TEXT_CLOSE singleton = new TEXT_CLOSE();
        private TEXT_CLOSE()
        {
        }

        public static TEXT_CLOSE Instance => singleton;
    }
}
