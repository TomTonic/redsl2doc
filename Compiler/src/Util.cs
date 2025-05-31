using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace org.redsl.Compiler
{
    public static partial class Util
    {
        public static void CheckGen(XDocument doc, string version, string gen)
        {
            XElement root = doc.Root;
            string verval = root.Attribute("version").Value;
            if (!verval.Equals(version))
            {
                throw new Exception("The (internal) XML Document is marked as version '" + verval + "', the compilation process expects version " + version + " at this point.");
            }
            string genval = root.Attribute("gen").Value;
            if (!genval.Equals(gen))
            {
                throw new Exception("The (internal) XML Document is marked as gen '" + genval + "', the compilation process expects version " + gen + " at this point.");
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
            if (result.Length > 1 && result.StartsWith('"'))
            {
                result = result[1..];
            }
            if (result.Length > 1 && result.EndsWith('"'))
            {
                result = result[..^1];
            }
            return result;
        }

        public static string UnescapeBackslashes(string s)
        {
            string result = EscapedBackslash().Replace(s, delegate (Match match)
            {
                string v = match.ToString();
                return v[1].ToString();
            });
            return result;
        }

        [GeneratedRegex(@"\\.")]
        private static partial Regex EscapedBackslash();

    }
}
