using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Cogensoft.SnippetManager.Presentation.Snippets.Models;
using Cogensoft.SnippetManager.Presentation.Snippets.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cogensoft.SnippetManager.Presentation.Snippets
{
    [RoutePrefix("snippets")]
    public class SnippetsController : Microsoft.AspNetCore.Mvc.Controller
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

        [Route("")]
        public Microsoft.AspNetCore.Mvc.ViewResult Index()
        {
            var snippets = _snippetsListQuery.Execute();

            return View(snippets);
        }

        [Route("{id:int}")]
        public Microsoft.AspNetCore.Mvc.ViewResult Detail(int id)
        {
            var snippet = _snippetDetailQuery.Execute(id);

            return View(snippet);
        }

        [Route("create")]
        public Microsoft.AspNetCore.Mvc.ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public RedirectToRouteResult Create(CreateSnippetViewModel viewModel)
        {
            var model = viewModel.Snippet;            

            _createCommand.Execute(model);

            return RedirectToAction("index", "snippets");
        }
    }
}