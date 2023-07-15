using Cogensoft.SnippetManager.Application.Interfaces;

namespace Cogensoft.SnippetManager.Specification.Common
{
    public class DatabaseLookup
    {
        private readonly IDatabaseService _database;

        public DatabaseLookup(IDatabaseService database)
        {
            _database = database;
        }

        public int GetSnippetId(string description)
        {
            return _database.Snippets
                .Single(p => p.Description == description).Id;
        }
    }
}
