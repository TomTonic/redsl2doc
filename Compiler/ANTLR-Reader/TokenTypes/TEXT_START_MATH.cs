using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_START_MATH : DiscardableTokenType
    {
        private static TEXT_START_MATH singleton = new TEXT_START_MATH();
        private TEXT_START_MATH()
        {
        }

        public static TEXT_START_MATH Instance => singleton;
    }
}
