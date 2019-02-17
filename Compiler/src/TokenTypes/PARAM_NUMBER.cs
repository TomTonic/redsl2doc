using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_NUMBER : TokenType
    {
        public override string XMLLabel => "number";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
