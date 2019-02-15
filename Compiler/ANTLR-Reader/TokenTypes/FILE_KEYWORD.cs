using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class FILE_KEYWORD : DiscardableTokenType
    {
        private static readonly FILE_KEYWORD singleton = new FILE_KEYWORD();
        private FILE_KEYWORD()
        {
        }

        public static FILE_KEYWORD Instance => singleton;
    }
}
