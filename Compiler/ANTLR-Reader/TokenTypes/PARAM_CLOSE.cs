using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class PARAM_CLOSE : DiscardableTokenType
    {
        private static PARAM_CLOSE singleton = new PARAM_CLOSE();
        private PARAM_CLOSE()
        {
        }

        public static PARAM_CLOSE Instance => singleton;
    }
}
