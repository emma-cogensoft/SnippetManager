﻿using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail;
using Cogensoft.SnippetManager.Common.Mocks;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;
using Moq.AutoMock;

namespace ApplicationTests.Snippets.Queries.GetSnippetDetail
{
    [TestFixture]
    public class GetSnippetDetailQueryTests
    {
        private GetSnippetDetailQuery _query = null!;
        private AutoMocker _mocker = null!;
        private Snippet _snippet = null!;

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

            _query = _mocker.CreateInstance<GetSnippetDetailQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnSnippetDetail()
        {
            // Arrange
            _mocker.GetMock<DbSet<Snippet>>()
                .SetUpDbSet(new List<Snippet>{ _snippet });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Snippets)
                .Returns(_mocker.GetMock<DbSet<Snippet>>().Object);

            // Act
            var result = _query.Execute(SnippetId);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Id,
                    Is.EqualTo(SnippetId));

                Assert.That(result.Date,
                    Is.EqualTo(Date));

                Assert.That(result.Description,
                    Is.EqualTo(Description));

                Assert.That(result.SnippetBody,
                    Is.EqualTo(SnippetBody));
            });
        }
    }
}
