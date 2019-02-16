using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PACKAGE_KEYWORD : DiscardableTokenType
    {
        private static PACKAGE_KEYWORD singleton = new PACKAGE_KEYWORD();
        private PACKAGE_KEYWORD()
        {
        }

        public static PACKAGE_KEYWORD Instance => singleton;
    }
}
