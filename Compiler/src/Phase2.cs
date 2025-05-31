using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace org.redsl.Compiler
{
    public static class Phase2
    {
        public static XDocument TokensToAttributes(XDocument doc)
        {
            Util.CheckGen(doc, "1.0", "1");
            XDocument result = new(doc);
            Util.SetGen(result, "1.0", "2");
            var tokenNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("token")))
                    )
                select AnyElement;
            XElement[] tokenNodeArray = [.. tokenNodes]; // cast it to array so we can manipulate (i.e. delete) the elements

            foreach (XElement node in tokenNodeArray)
            {
                PromoteToAttribute(node);
            }
            return result;
        }

        private static void PromoteToAttribute(XElement node)
        {
            XElement parent = node.Parent;
            string type = node.Attribute("type").Value;
            string value = node.Attribute("value").Value;

            XAttribute oldVal = parent.Attribute(type);
            if (oldVal != null)
            {
                value = oldVal.Value + " " + value;
            }

            parent.SetAttributeValue(type, value);
            node.Remove();
        }
    }
}
