using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_COMMENT : TokenType
    {
        public override string XMLLabel => "comment";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
