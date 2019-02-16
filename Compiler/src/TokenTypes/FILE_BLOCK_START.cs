using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class FILE_BLOCK_START : DiscardableTokenType
    {
        private static readonly FILE_BLOCK_START singleton = new FILE_BLOCK_START();
        private FILE_BLOCK_START()
        {
        }

        public static FILE_BLOCK_START Instance => singleton;
    }
}
