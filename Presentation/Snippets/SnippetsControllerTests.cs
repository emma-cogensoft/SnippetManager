using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Cogensoft.SnippetManager.Presentation.Snippets.Models;
using Cogensoft.SnippetManager.Presentation.Snippets.Services;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Presentation.Snippets
{
    [TestFixture]
    public class SnippetsControllerTests
    {
        private SnippetsController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<SnippetsController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfSnippets()
        {
            var model = new SnippetsListItemModel();

            _mocker.GetMock<IGetSnippetsListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SnippetsListItemModel> { model });

            var viewResult = _controller.Index();

            var results = (List<SnippetsListItemModel>) viewResult.Model;

            Assert.That(results.Single(), Is.EqualTo(model));
        }

        [Test]
        public void TestGetDetailShouldReturnSnippetDetail()
        {
            var snippetId = 1;

            var model = new SnippetDetailModel();

            _mocker.GetMock<IGetSnippetDetailQuery>()
                .Setup(p => p.Execute(snippetId))
                .Returns(model);

            var viewResult = _controller.Detail(snippetId);

            var result = (SnippetDetailModel) viewResult.Model;

            Assert.That(result, Is.EqualTo(model));
        }

        [Test]
        public void TestGetCreateShouldReturnCreateSnippetViewModel()
        {
            var viewModel = new CreateSnippetViewModel();

            _mocker.GetMock<ICreateSnippetViewModelFactory>()
                .Setup(p => p.Create())
                .Returns(viewModel);

            var viewResult = _controller.Create();

            var result = (CreateSnippetViewModel) viewResult.Model;

            Assert.That(result, Is.EqualTo(viewModel));
        }

        [Test]
        public void TestPostCreateShouldReturnExecuteCreateSnippetCommand()
        {
            var model = new CreateSnippetModel();

            var viewModel = new CreateSnippetViewModel
            {
                Snippet = model
            };

            _controller.Create(viewModel);

            _mocker.GetMock<ICreateSnippetCommand>()
                .Verify(p => p.Execute(model));
        }
    }
}