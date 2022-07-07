using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;

namespace Cogensoft.SnippetManager.Service.Snippets
{
    public class SnippetsController : ApiController
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

        public IEnumerable<SnippetsListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        public SnippetDetailModel Get(int id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateSnippetModel snippet)
        {
            _createCommand.Execute(snippet);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
