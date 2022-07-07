using System.Linq;
using Cogensoft.SnippetManager.Application.Interfaces;

namespace Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail
{
    public class GetSnippetDetailQuery
        : IGetSnippetDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetSnippetDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public SnippetDetailModel Execute(int snippetId)
        {
            var snippet = _database.Snippets
                .Where(p => p.Id == snippetId)
                .Select(p => new SnippetDetailModel
                {
                    Id = p.Id, 
                    Date = p.Date,
                    Description = p.Description,
                    SnippetBody = p.SnippetBody
                })
                .Single();

            return snippet;
        }
    }
}
