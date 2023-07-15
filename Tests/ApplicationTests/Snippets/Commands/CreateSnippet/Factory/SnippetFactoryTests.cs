using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet.Factory;

namespace ApplicationTests.Snippets.Commands.CreateSnippet.Factory
{
    [TestFixture]
    public class SnippetFactoryTests
    {
        private SnippetFactory _factory = null!;

        private static readonly DateTime DateTime = new DateTime(2022, 2, 3);
        private const string Description = "Snippet description";
        private const string SnippetBody = "Snippet body";
        

        [SetUp]
        public void SetUp()
        {
            _factory = new SnippetFactory();
        }

        [Test]
        public void TestCreateShouldCreateSnippet()
        {
            var result = _factory.Create(DateTime, Description, SnippetBody);

            Assert.That(result.Date, Is.EqualTo(DateTime));
            Assert.That(result.Description, Is.EqualTo(Description));
            Assert.That(result.SnippetBody, Is.EqualTo(SnippetBody));
        }
    }
}
