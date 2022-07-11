using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetsList;
using Cogensoft.SnippetManager.Common.Mocks;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;
using Moq.AutoMock;

namespace ApplicationTests.Snippets.Queries.GetSnippetsList
{
    [TestFixture]
    public class GetSnippetsListQueryTests
    {
        private GetSnippetsListQuery _query;
        private AutoMocker _mocker;
        private Snippet _snippet;

        private const int SnippetId = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const string Description = "Snippet description";
        private const string SnippetBody = "Snippet body";

        [SetUp]
        public void SetUp()
        {
            _snippet = new Snippet
            {
                Id = SnippetId,
                Date = Date,
                Description = Description,
                SnippetBody = SnippetBody
            };

            _mocker = new AutoMocker();

            _query = _mocker.CreateInstance<GetSnippetsListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfSnippets()
        {
            _mocker.GetMock<DbSet<Snippet>>()
                .SetUpDbSet(new List<Snippet> { _snippet });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Snippets)
                .Returns(_mocker.GetMock<DbSet<Snippet>>().Object);

            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, 
                Is.EqualTo(SnippetId));

            Assert.That(result.Date, 
                Is.EqualTo(Date));

            Assert.That(result.Description, 
                Is.EqualTo(Description));
        }
    }    
}
