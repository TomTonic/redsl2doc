using System;
using System.Linq;
using System.Collections.Generic;

namespace org.redsl.Compiler.TokenTypes
{
    public static class TokenTypeFactory
    {
        private static readonly Dictionary<string, TokenType> map = new Dictionary<string, TokenType>();

        static TokenTypeFactory()
        {
            var subclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(TokenType))
                select type;
            foreach (var subclass in subclasses)
            {
                string name = subclass.Name;
                try
                {
                    TokenType tt = (TokenType)Activator.CreateInstance(subclass);
                    map.Add(name, tt);
                }
                catch (Exception)
                { }

            }
        }

        public static TokenType GetTokenType(string name)
        {
            return map[name];
        }
    }
}