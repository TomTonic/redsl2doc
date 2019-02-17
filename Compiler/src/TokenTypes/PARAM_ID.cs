using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class PARAM_ID : TokenType
    {
        public override string XMLLabel => "id";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
