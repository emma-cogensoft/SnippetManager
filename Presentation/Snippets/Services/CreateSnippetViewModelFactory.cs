using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Presentation.Snippets.Models;

namespace Cogensoft.SnippetManager.Presentation.Snippets.Services
{
    public class CreateSnippetViewModelFactory : ICreateSnippetViewModelFactory
    {

        public CreateSnippetViewModelFactory()
        {
        }

        public CreateSnippetViewModel Create()
        {
            var viewModel = new CreateSnippetViewModel
            {
                Snippet = new CreateSnippetModel()
            };

            return viewModel;
        }
    }
}