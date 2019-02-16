using System;
using System.Xml.Linq;
namespace org.redsl.Compiler.TokenTypes
{
    public abstract class DiscardableTokenType : TokenType
    {
        public override string XMLLabel => GrammarLabel;

        public override void TidyToken(XElement node)
        {
            node.Remove();
        }
    }
}
