using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_EQUALS : DiscardableTokenType
    {
        private static PARAM_EQUALS singleton = new PARAM_EQUALS();
        private PARAM_EQUALS()
        {
        }

        public static PARAM_EQUALS Instance => singleton;
    }
}
