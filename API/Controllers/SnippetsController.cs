using Cogensoft.SnippetManager.Application.Exceptions;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly IGetSnippetsListQuery _listQuery;
        private readonly IGetSnippetDetailQuery _detailQuery;
        private readonly ICreateSnippetCommand _createCommand;

        public SnippetsController(
            IGetSnippetsListQuery listQuery,
            IGetSnippetDetailQuery detailQuery,
            ICreateSnippetCommand createCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
        }

        // GET: api/Snippets
        [HttpGet]
        public ActionResult<IEnumerable<Snippet>> GetSnippets()
        {
            return Ok(_listQuery.Execute());
        }

        // GET: api/Snippets/5
        [HttpGet("{id}")]
        public ActionResult<Snippet> GetSnippet(int id)
        {
            try
            {
                return Ok(_detailQuery.Execute(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Snippets
        [HttpPost]
        public async Task<ActionResult<Snippet>> PostSnippet(CreateSnippetModel model)
        {
            _createCommand.Execute(model);
            return Ok();
        }
    }
}
