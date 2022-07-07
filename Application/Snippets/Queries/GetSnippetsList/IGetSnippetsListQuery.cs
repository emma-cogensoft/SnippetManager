using System.Collections.Generic;

namespace Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList
{
    public interface IGetSnippetsListQuery
    {
        List<SnippetsListItemModel> Execute();
    }
}