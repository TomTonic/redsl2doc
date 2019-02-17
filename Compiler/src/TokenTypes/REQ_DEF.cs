using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class REQ_DEF : TokenType
    {
        public override string XMLLabel => "requirement";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
