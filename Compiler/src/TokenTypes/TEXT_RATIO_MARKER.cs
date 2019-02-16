using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_RATIO_MARKER : DiscardableTokenType
    {
        private static TEXT_RATIO_MARKER singleton = new TEXT_RATIO_MARKER();
        private TEXT_RATIO_MARKER()
        {
        }

        public static TEXT_RATIO_MARKER Instance => singleton;

    }
}
