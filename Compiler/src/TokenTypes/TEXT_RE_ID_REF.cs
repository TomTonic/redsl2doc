using System;
using System.Xml.Linq;

namespace org.redsl.Compiler.TokenTypes
{
    public class TEXT_RE_ID_REF : TokenType
    {
        public override string XMLLabel => "reqref";

        public override void TidyToken(XElement node)
        {
            string value = node.Attribute("value").Value;
            node.Name = "ref";
            node.RemoveAttributes();
            node.SetAttributeValue("value", value);
        }
    }
}
