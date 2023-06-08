using System.Collections.Concurrent;

namespace ASP_Projekat_API.Jwt.TokenStorage
{
    public class InMemoryTokenStorage : ITokenStorage
    {
        private static ConcurrentDictionary<string, bool> Tokens { get; }

        static InMemoryTokenStorage()
        {
            Tokens = new ConcurrentDictionary<string, bool>();
        }

        public void AddToken(string id)
        {
            Tokens.TryAdd(id, true);
        }

        public bool TokenExists(string id)
        {
            bool tokenExists = Tokens.ContainsKey(id);

            if (!tokenExists)
            {
                return false;
            }

            return Tokens[id];
        }

        public void InvalidateToken(string id)
        {
            bool value = false;
            Tokens.Remove(id, out value);
        }
    }
}
