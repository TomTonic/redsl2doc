using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using org.redsl.Compiler.TokenTypes;

namespace org.redsl.Compiler
{
    public static class Phase1
    {
        public static XDocument TidyTokens(XDocument doc)
        {
            Util.CheckGen(doc, "1.0", "0");
            XDocument result = new XDocument(doc);
            Util.SetGen(result, "1.0", "1");
            IEnumerable<XElement> tokenNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("token")))
                    )
                select AnyElement;
            XElement[] tokenNodeArray = tokenNodes.ToArray(); // cast it to array so we can manipulate (i.e. delete) the elements

            foreach (XElement node in tokenNodeArray)
            {
                TidyToken(node);
            }
            return result;
        }

        private static void TidyToken(XElement node)
        {
            string type = node.Attribute("type").Value;
            TokenType tt = TokenTypeFacory.GetTokenType(type);
            if (tt == null)
            {
                throw new Exception("Unknown token type '" + type + "'. The parser code and the compiler code seem out of sync.");
            }
            tt.TidyToken(node);
        }
    }
}
