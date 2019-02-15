using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_ID_LIST_END : DiscardableTokenType
    {
        private static PARAM_ID_LIST_END singleton = new PARAM_ID_LIST_END();
        private PARAM_ID_LIST_END()
        {
        }

        public static PARAM_ID_LIST_END Instance => singleton;

    }
}
