using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_START : DiscardableTokenType
    {
        private static PARAM_START singleton = new PARAM_START();
        private PARAM_START()
        {
        }

        public static PARAM_START Instance => singleton;
    }
}
