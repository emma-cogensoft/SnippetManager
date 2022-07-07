using System.Collections.Generic;
using System.Net;
using AutoMoq;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Moq;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Service.Snippets
{
    [TestFixture]
    public class SnippetsControllerTests
    {
        private SnippetsController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<SnippetsController>();
        }

        [Test]
        public void TestGetShouldReturnListOfSnippets()
        {
            var snippet = new SnippetsListItemModel();

            _mocker.GetMock<IGetSnippetsListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SnippetsListItemModel> {snippet} );

            var result = _controller.Get();

            Assert.That(result, 
                Contains.Item(snippet));
        }

        [Test]
        public void TestGetShouldReturnSnippetDetails()
        {
            var snippet = new SnippetDetailModel();

            _mocker.GetMock<IGetSnippetDetailQuery>()
                .Setup(p => p.Execute(1))
                .Returns(snippet);

            var result = _controller.Get(1);

            Assert.That(result,
                Is.EqualTo(snippet));
        }

        [Test]
        public void TestCreateSnippetShouldCreateSnippet()
        {
            var snippet = new CreateSnippetModel();

            var result = _controller.Create(snippet);

            _mocker.GetMock<ICreateSnippetCommand>()
                .Verify(p => p.Execute(snippet),
                    Times.Once);

            Assert.That(result.StatusCode, 
                Is.EqualTo(HttpStatusCode.Created));
        }
    }
}