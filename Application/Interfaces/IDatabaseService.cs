using System.Threading.Tasks;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;

namespace Cogensoft.SnippetManager.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Snippet> Snippets { get; set; }

        Task SaveAsync();
    }
}