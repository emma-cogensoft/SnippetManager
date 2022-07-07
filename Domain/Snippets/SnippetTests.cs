using System;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Domain.Snippets
{
    [TestFixture]
    public class SnippetTests
    {
        private Snippet _snippet;

        private const int Id = 1;
        private static readonly DateTime Date = new DateTime(2022, 2, 3);
        private const string Description = "Some test description";
        private const string SnippetBody = "Some test snippet body";

        [SetUp]
        public void SetUp()
        {
            _snippet = new Snippet();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _snippet.Id = Id;

            Assert.That(_snippet.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            _snippet.Date = Date;

            Assert.That(_snippet.Date,
                Is.EqualTo(Date));
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _snippet.Description = Description;

            Assert.That(_snippet.Description,
                Is.EqualTo(Description));
        }
        
        [Test]
        public void TestSetAndGetSnippetBody()
        {
            _snippet.SnippetBody = SnippetBody;

            Assert.That(_snippet.SnippetBody,
                Is.EqualTo(SnippetBody));
        }
    }
}
