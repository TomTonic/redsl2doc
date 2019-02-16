using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_LINE_BREAK : DiscardableTokenType
    {
        private static TEXT_LINE_BREAK singleton = new TEXT_LINE_BREAK();
        private TEXT_LINE_BREAK()
        {
        }

        public static TEXT_LINE_BREAK Instance => singleton;
    }
}
