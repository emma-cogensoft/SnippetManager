using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services.Snippets;

namespace Presentation.Controllers
{
    public class SnippetsController : Controller
    {
        private readonly IGetSnippetsListQuery _snippetsListQuery;
        private readonly IGetSnippetDetailQuery _snippetDetailQuery;
        private readonly ICreateSnippetViewModelFactory _factory;
        private readonly ICreateSnippetCommand _createCommand;

        public SnippetsController(
            IGetSnippetsListQuery snippetsListQuery,
            IGetSnippetDetailQuery snippetDetailQuery,
            ICreateSnippetViewModelFactory factory,
            ICreateSnippetCommand createCommand)
        {
            _snippetsListQuery = snippetsListQuery;
            _snippetDetailQuery = snippetDetailQuery;
            _factory = factory;
            _createCommand = createCommand;
        }
        
        public ViewResult List()
        {
            var snippets = _snippetsListQuery.Execute();

            return View(snippets);
        }
        
        public ViewResult Detail(int id)
        {
            var snippet = _snippetDetailQuery.Execute(id);

            return View(snippet);
        }
        
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSnippetViewModel? viewModel)
        {
            var model = viewModel!.Snippet;            

            await _createCommand.ExecuteAsync(model);

            return RedirectToAction("List", "Snippets");
        }
    }
}