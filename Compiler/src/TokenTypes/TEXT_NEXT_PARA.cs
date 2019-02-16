using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_NEXT_PARA : DiscardableTokenType
    {
        private static TEXT_NEXT_PARA singleton = new TEXT_NEXT_PARA();
        private TEXT_NEXT_PARA()
        {
        }

        public static TEXT_NEXT_PARA Instance => singleton;
    }
}
