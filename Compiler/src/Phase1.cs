using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace org.redsl.Compiler
{
    public static class Phase1
    {
        private static readonly HashSet<string> DiscardTokens =
            new HashSet<string>(new string[] { "FILE_KEYWORD", "FILE_BLOCK_START",
            "FILE_BLOCK_END", "PACKAGE_KEYWORD", "WS", "PARAM_START", "TEXT_START",
            "REQ_DEF_WS", "TEXT_CLOSE", "TEXT_WS", "TEXT_LINE_BREAK", "TEXT_NEXT_PARA",
            "TEXT_EXAMPLE_MARKER", "TEXT_RATIO_MARKER", "TEXT_REF_MARKER",
            "TEXT_START_MATH", "PARAM_CLOSE", "PARAM_EQUALS", "PARAM_ID_LIST_START",
            "PARAM_ID_LIST_SEP", "PARAM_ID_LIST_END", "PARAM_WS", "MATH_CLOSE"  });

        private static readonly HashSet<string> TrimQuotesTokens =
            new HashSet<string>(new string[] { "ID_STR", "ID_STR_ESC_SEQ",
            "TEXT_ESC_SEQ", "MATH_ESC_SEQ" });

        private static readonly HashSet<string> UnescapeBackslashesTokens =
            new HashSet<string>(new string[] { "ID_STR_ESC_SEQ", "TEXT_ESC_SEQ" });

        private static readonly HashSet<string> UnescapeDollarTokens =
            new HashSet<string>(new string[] { "MATH_ESC_SEQ" });

        private static readonly HashSet<string> KeepAsTheyAreTokens =
            new HashSet<string>(new string[] { "REQ_DEF", "TEXT_COMMENT",
            "TEXT_RE_ID_REF", "TEXT_URI", "TEXT_TERM_REF", "TEXT_CONTENT",
            "PARAM_ID", "PARAM_STRING", "PARAM_BOOL", "PARAM_NUMBER", "MATH_CONTENT" });

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
            Console.Write("Tidying " + node + "...");

            string type = node.Attribute("type").Value;
            string value = node.Attribute("value").Value;
            Boolean foundToken = false;


            if (DiscardTokens.Contains(type))
            {
                foundToken = true;  // superflous, but make things clear
                node.Remove();
                Console.WriteLine(" removed.");
                return;
            }

            if (KeepAsTheyAreTokens.Contains(type))
            {
                foundToken = true;  // superflous, but make things clear
                Console.WriteLine(" ok.");
                return;
            }

            if (TrimQuotesTokens.Contains(type))
            {
                foundToken = true;
                value = Util.TrimQuotes(value);
                Console.Write(" trimed quotes");
            }

            if (UnescapeBackslashesTokens.Contains(type))
            {
                foundToken = true;
                value = Util.UnescapeBackslashes(value);
                Console.Write(" unescaped backslashes");
            }

            if (UnescapeDollarTokens.Contains(type))
            {
                foundToken = true;
                value = Util.UnescapeBackslashes(value);
                Console.Write(" unescaped backslashes in math mode");
            }

            if (foundToken)
            {
                node.Attribute("value").Value = value;
            }
            else
            {
                throw new Exception("unknown token type - the grammar and this code module seem out of sync");
            }
            Console.WriteLine(".");
        }
    }
}
