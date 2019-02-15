using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class MATH_CLOSE : DiscardableTokenType
    {
        private static MATH_CLOSE singleton = new MATH_CLOSE();
        private MATH_CLOSE()
        {
        }

        public static MATH_CLOSE Instance => singleton;
    }
}
