using Moq.AutoMock;
using NUnit.Framework;

namespace Presentation.Services.Snippets
{
    [TestFixture]
    public class CreateSnippetViewModelFactoryTests
    {
        private CreateSnippetViewModelFactory _factory;
        private AutoMocker _mocker;
        
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