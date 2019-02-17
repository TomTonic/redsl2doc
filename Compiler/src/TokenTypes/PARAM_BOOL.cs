using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_BOOL : TokenType
    {
        public override string XMLLabel => "bool";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
