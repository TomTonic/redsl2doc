using System;
using System.Linq;
using System.Collections.Generic;

namespace org.redsl.Compiler.TokenTypes
{
    public class TokenTypeFacory
    {
        private static readonly Dictionary<string, TokenType> map = new Dictionary<string, TokenType>();

        static TokenTypeFacory()
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
            Console.WriteLine(map);
        }

        public static TokenType GetTokenType(string name)
        {
            return map[name];
        }
    }
}