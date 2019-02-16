using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_ID_LIST_SEP : DiscardableTokenType
    {
        private static PARAM_ID_LIST_SEP singleton = new PARAM_ID_LIST_SEP();
        private PARAM_ID_LIST_SEP()
        {
        }

        public static PARAM_ID_LIST_SEP Instance => singleton;
    }
}
