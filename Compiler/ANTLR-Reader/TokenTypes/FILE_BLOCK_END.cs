using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class FILE_BLOCK_END : DiscardableTokenType
    {
        private static readonly FILE_BLOCK_END singleton = new FILE_BLOCK_END();
        private FILE_BLOCK_END()
        {
        }

        public static FILE_BLOCK_END Instance => singleton;
    }
}
