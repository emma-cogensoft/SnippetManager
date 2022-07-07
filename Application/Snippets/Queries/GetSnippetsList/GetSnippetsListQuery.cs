using System.Collections.Generic;
using System.Linq;
using Cogensoft.SnippetManager.Application.Interfaces;

namespace Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList
{
    public class GetSnippetsListQuery 
        : IGetSnippetsListQuery
    {
        private readonly IDatabaseService _database;

        public GetSnippetsListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<SnippetsListItemModel> Execute()
        {
            var snippets = _database.Snippets
                .Select(p => new SnippetsListItemModel
                {
                    Id = p.Id, 
                    Date = p.Date,
                    Description = p.Description
                });

            return snippets.ToList();
        }
    }
}
