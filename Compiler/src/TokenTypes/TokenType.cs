using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public abstract class TokenType
    {
        private readonly string grammarLabel;
        protected TokenType()
        {
            grammarLabel = this.GetType().Name;
        }
        public string GrammarLabel => grammarLabel;
        public abstract string XMLLabel { get; }

        public abstract void TidyToken(XElement node);
    }
}
