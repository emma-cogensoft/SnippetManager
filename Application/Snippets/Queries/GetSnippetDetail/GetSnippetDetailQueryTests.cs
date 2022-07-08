using System;
using System.Collections.Generic;
using AutoMoq;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Common.Mocks;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Application.Snippets.Queries.GetSnippetDetail
{
    [TestFixture]
    public class GetSnippetDetailQueryTests
    {
        private GetSnippetDetailQuery _query;
        private AutoMoqer _mocker;
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

            _mocker = new AutoMoqer();

            _query = _mocker.Create<GetSnippetDetailQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnSnippetDetail()
        {
            _mocker.GetMock<DbSet<Snippet>>()
                .SetUpDbSet(new List<Snippet> {_snippet });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Snippets)
                .Returns(_mocker.GetMock<DbSet<Snippet>>().Object);

            var result = _query.Execute(SnippetId);

            Assert.That(result.Id, 
                Is.EqualTo(SnippetId));

            Assert.That(result.Date, 
                Is.EqualTo(Date));

            Assert.That(result.Description, 
                Is.EqualTo(Description));

            Assert.That(result.SnippetBody, 
                Is.EqualTo(SnippetBody));
        }
    }
}
