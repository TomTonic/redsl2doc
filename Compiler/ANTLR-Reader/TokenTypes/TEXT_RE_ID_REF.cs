using System;
using System.Xml.Linq;

namespace org.redsl.ANTLRReader.TokenTypes
{
    public class TEXT_RE_ID_REF : TokenType
    {
        private static TEXT_RE_ID_REF singleton = new TEXT_RE_ID_REF();
        private TEXT_RE_ID_REF()
        {
        }

        public static TEXT_RE_ID_REF Instance => singleton;

        public override string XMLLabel => "reqref";

        public override void TidyToken(XElement node)
        {
            throw new Exception("todo");
        }
    }
}
