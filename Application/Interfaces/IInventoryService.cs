using System.Threading.Tasks;

namespace Cogensoft.SnippetManager.Application.Interfaces
{
    public interface INotificationService
    {
        Task NotifySnippetCreatedAsync(int snippetId, string description);
    }
}
