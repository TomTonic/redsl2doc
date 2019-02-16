using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_REF_MARKER : DiscardableTokenType
    {
        private static TEXT_REF_MARKER singleton = new TEXT_REF_MARKER();
        private TEXT_REF_MARKER()
        {
        }

        public static TEXT_REF_MARKER Instance => singleton;
    }
}
