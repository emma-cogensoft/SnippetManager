using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMoq;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet.Factory;
using Cogensoft.SnippetManager.Common.Dates;
using Cogensoft.SnippetManager.Common.Mocks;
using Cogensoft.SnippetManager.Domain.Snippets;
using Moq;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet
{
    [TestFixture]
    public class CreateSnippetCommandTests
    {
        private CreateSnippetCommand _command;
        private AutoMoqer _mocker;
        private CreateSnippetModel _model;
        private Snippet _snippet;

        private static readonly DateTime Date = new DateTime(2022, 2, 3);
        private const string Description = "Snippet description";
        private const string SnippetBody = "Snippet body";

        [SetUp]
        public void SetUp()
        {
            _model = new CreateSnippetModel
            {
                Description = Description,
                SnippetBody = SnippetBody
            };

            _snippet = new Snippet();
            
            _mocker = new AutoMoqer();

            _mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            SetUpDbSet(p => p.Snippets);

            _mocker.GetMock<ISnippetFactory>()
                .Setup(p => p.Create(
                    Date,
                    Description,
                    SnippetBody))
                .Returns(_snippet);
            
            _command = _mocker.Create<CreateSnippetCommand>();
        }

        [Test]
        public void TestExecuteShouldAddSnippetToTheDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDbSet<Snippet>>()
                .Verify(p => p.Add(_snippet),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDatabaseService>()
                .Verify(p => p.Save(),
                    Times.Once);
        }
        
        [Test]
        public void TestExecuteShouldNotifyThatSnippetOccurred()
        {
            _command.Execute(_model);
        
            _mocker.GetMock<INotificationService>()
                .Verify(p => p.NotifySnippetCreated(
                        Description,
                        new DateTime()),
                    Times.Once);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property, T entity)
            where T : class
        {
            _mocker.GetMock<IDbSet<T>>()
               .SetUpDbSet(new List<T> { entity });

            _mocker.GetMock<IDatabaseService>()
               .Setup(property)
               .Returns(_mocker.GetMock<IDbSet<T>>().Object);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property)
           where T : class
        {
            _mocker.GetMock<IDbSet<T>>()
               .SetUpDbSet(new List<T>());

            _mocker.GetMock<IDatabaseService>()
               .Setup(property)
               .Returns(_mocker.GetMock<IDbSet<T>>().Object);
        }
    }
}
