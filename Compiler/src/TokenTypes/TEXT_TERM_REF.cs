using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_TERM_REF : TokenType
    {
        public override string XMLLabel => "term";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
