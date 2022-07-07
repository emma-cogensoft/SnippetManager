using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Presentation.Snippets.Services
{
    [TestFixture]
    public class CreateSnippetViewModelFactoryTests
    {
        private CreateSnippetViewModelFactory _factory;
        private AutoMoqer _mocker;

        private const int CustomerId = 1;
        private const string CustomerName = "Customer 1";
        private const int EmployeeId = 2;
        private const string EmployeeName = "Employee 2";
        private const int ProductId = 3;
        private const string ProductName = "Product 3";
        private const decimal ProductPrice = 1.23m;
        
        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _factory = _mocker.Create<CreateSnippetViewModelFactory>();
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