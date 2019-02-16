using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_EXAMPLE_MARKER : DiscardableTokenType
    {
        private static TEXT_EXAMPLE_MARKER singleton = new TEXT_EXAMPLE_MARKER();
        private TEXT_EXAMPLE_MARKER()
        {
        }

        public static TEXT_EXAMPLE_MARKER Instance => singleton;
    }
}
