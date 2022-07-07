using System.Data.Entity;
using Cogensoft.SnippetManager.Domain.Snippets;

namespace Cogensoft.SnippetManager.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Snippet> Snippets { get; set; }

        void Save();
    }
}