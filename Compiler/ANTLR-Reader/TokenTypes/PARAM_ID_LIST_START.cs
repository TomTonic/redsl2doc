using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_ID_LIST_START : DiscardableTokenType
    {
        private static PARAM_ID_LIST_START singleton = new PARAM_ID_LIST_START();
        private PARAM_ID_LIST_START()
        {
        }

        public static PARAM_ID_LIST_START Instance => singleton;
    }
}
