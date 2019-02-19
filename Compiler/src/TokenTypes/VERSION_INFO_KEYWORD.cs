using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class VERSION_INFO_KEYWORD : TokenType
    {
        public override string XMLLabel => "version-info";

        public override void TidyToken(XElement node)
        {
            node.Name = "version-info";
            node.RemoveAttributes();
        }
    }
}