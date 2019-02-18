using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_WS : TokenType
    {
        public override string XMLLabel => "ws";

        public override void TidyToken(XElement node)
        {
            node.Name = "ws";
            node.RemoveAttributes();
        }
    }
}
