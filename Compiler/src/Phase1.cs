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
            XDocument result = new(doc);
            Util.SetGen(result, "1.0", "0.5");
            IEnumerable<XElement> tokenNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("token")))
                    )
                select AnyElement;
            XElement[] tokenNodeArray = [.. tokenNodes]; // cast it to array so we can manipulate (i.e. delete) the elements

            foreach (XElement node in tokenNodeArray)
            {
                TidyToken(node);
            }
            return result;
        }

        private static void TidyToken(XElement node)
        {
            string type = node.Attribute("type").Value;
            TokenType tt = TokenTypeFactory.GetTokenType(type) ?? throw new Exception("Unknown token type '" + type + "'. The parser code and the compiler code seem out of sync.");
            tt.TidyToken(node);
        }

        public static XDocument ReduceTextNodes(XDocument doc)
        {
            Util.CheckGen(doc, "1.0", "0.5");
            XDocument result = new(doc);
            Util.SetGen(result, "1.0", "1");
            IEnumerable<XElement> RunningTextNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("RunningText")))
                    )
                select AnyElement;
            XElement[] textNodeArray = [.. RunningTextNodes]; // cast it to array so we can manipulate (i.e. delete) the elements

            foreach (XElement node in textNodeArray)
            {
                ReduceTextNodesInRunningTextNode(node);
            }
            return result;
        }

        private static void ReduceTextNodesInRunningTextNode(XElement node)
        {
            TrimWS(node);
            XElement[] children = [.. node.Descendants()];
            if (children.Length <= 1) return;

            XElement current = children[0];
            int i = 1;
            do
            {
                XElement next = CheckAppendTextValue(current, children[i]);
                current = next;
                i++;
            } while (i < children.Length);
        }

        private static void TrimWS(XElement node)
        {
            XElement[] children = [.. node.Descendants()];
            XName ws = XName.Get("ws");
            int i = 0;
            while (i < children.Length && children[i].Name.Equals(ws))
            {
                children[i].Remove();
                i++;
            }
            if (i < children.Length)
            {
                int j = children.Length - 1;
                while (j > 0 && children[j].Name.Equals(ws))
                {
                    children[j].Remove();
                    j--;
                }
            }
        }

        private static XElement CheckAppendTextValue(XElement current, XElement next)
        {
            string typeCurrent = current.Name.ToString();
            string typeNext = next.Name.ToString();
            if ("text".Equals(typeCurrent) && "text".Equals(typeNext))
            {
                string valueCurrent = current.Attribute("value").Value;
                string valueNext = next.Attribute("value").Value;
                current.SetAttributeValue("value", valueCurrent + valueNext);
                next.Remove();
                return current;
            }
            if ("text".Equals(typeCurrent) && "ws".Equals(typeNext))
            {
                string valueCurrent = current.Attribute("value").Value;
                if (!valueCurrent.Last().Equals(' '))
                {
                    current.SetAttributeValue("value", valueCurrent + " ");
                }
                next.Remove();
                return current;
            }
            if ("ws".Equals(typeCurrent) && "text".Equals(typeNext))
            {
                string valueNext = next.Attribute("value").Value;
                if (!valueNext.First().Equals(' '))
                {
                    next.SetAttributeValue("value", " " + valueNext);
                }
                current.Remove();
                return next;
            }
            if ("ws".Equals(typeCurrent) && "ws".Equals(typeNext))
            {
                next.Remove();
                return current;
            }
            return next;
        }
    }
}
