using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class MATH_CONTENT : TokenType
    {
        private static MATH_CONTENT singleton = new MATH_CONTENT();
        private MATH_CONTENT()
        {
        }

        public static MATH_CONTENT Instance => singleton;

        public override string XMLLabel => "math";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
