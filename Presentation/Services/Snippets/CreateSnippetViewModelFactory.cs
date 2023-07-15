using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Presentation.Models;

namespace Presentation.Services.Snippets
{
    public class CreateSnippetViewModelFactory : ICreateSnippetViewModelFactory
    {
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