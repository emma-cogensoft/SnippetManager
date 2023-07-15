using Moq.AutoMock;
using Presentation.Services.Snippets;

namespace PresentationTests.Services.Snippets
{
    [TestFixture]
    public class CreateSnippetViewModelFactoryTests
    {
        private CreateSnippetViewModelFactory _factory = null!;
        private AutoMocker _mocker = null!;
        
        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();
            _factory = _mocker.CreateInstance<CreateSnippetViewModelFactory>();
        }

        [Test]
        public void TestCreateShouldCreateEmptySnippetModel()
        {
            var viewModel = _factory.Create();

            var result = viewModel.Snippet;

            Assert.That(result, Is.Not.Null);
        }
    }
}