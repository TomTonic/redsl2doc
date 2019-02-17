using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_STRING : TokenType
    {
        public override string XMLLabel => "string";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
