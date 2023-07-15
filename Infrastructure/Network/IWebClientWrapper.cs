using System.Threading.Tasks;

namespace Cogensoft.SnippetManager.Infrastructure.Network
{
    public interface IWebClientWrapper
    {
        Task PostAsync(string address, string json);
    }
}