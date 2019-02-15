using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader
{
    public static class Util
    {
        public static void CheckGen(XDocument doc, string version, string gen )
        {
            XElement root = doc.Root;
            string verval = root.Attribute("version").Value;
            if (!verval.Equals(version))
            {
                throw new Exception("XML Document not marked as version "+version+".");
            }
            string genval = root.Attribute("gen").Value;
            if (!genval.Equals(gen))
            {
                throw new Exception("XML Document not marked as gen "+gen+".");
            }
        }

        public static void SetGen(XDocument doc, string version, string gen)
        {
            XElement root = doc.Root;
            root.Attribute("version").Value = version;
            root.Attribute("gen").Value = gen;
        }

        public static string TrimQuotes(string s)
        {
            string result = s;
            if (result.Length > 1 && result.StartsWith("\"", StringComparison.Ordinal))
            {
                result = result.Substring(1);
            }
            if (result.Length > 1 && result.EndsWith("\"", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }

        public static string UnescapeBackslashes(string s)
        {
            string result = Regex.Replace(s, @"\\.", delegate (Match match)
            {
                string v = match.ToString();
                return v[1].ToString();
            });
            return result;
        }
    }
}
