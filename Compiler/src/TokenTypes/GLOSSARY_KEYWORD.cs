using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class GLOSSARY_KEYWORD : TokenType
    {
        public override string XMLLabel => "glossary";

        public override void TidyToken(XElement node)
        {
            node.Name = "glossary";
            node.RemoveAttributes();
            node.SetAttributeValue("mode", "global");
        }
    }
}