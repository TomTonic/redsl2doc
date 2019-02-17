using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_URI : TokenType
    {
        public override string XMLLabel => "uri";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
