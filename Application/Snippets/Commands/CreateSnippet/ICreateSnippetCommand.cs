using System.Threading.Tasks;

namespace Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet
{
    public interface ICreateSnippetCommand
    {
        Task ExecuteAsync(CreateSnippetModel model);
    }
}