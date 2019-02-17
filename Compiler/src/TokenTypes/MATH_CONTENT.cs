using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class MATH_CONTENT : TokenType
    {
        public override string XMLLabel => "math";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
