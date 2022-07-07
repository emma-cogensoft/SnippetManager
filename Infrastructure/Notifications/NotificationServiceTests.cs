using System;
using AutoMoq;
using Cogensoft.SnippetManager.Infrastructure.Network;
using Moq;
using NUnit.Framework;

namespace Cogensoft.SnippetManager.Infrastructure.Notifications
{
    [TestFixture]
    public class NotificationServiceTests
    {
        private NotificationService _service;
        private AutoMoqer _mocker;

        private const string Address = "http://abc123.com/notification/snippets/1/notifysnippetcreated/";
        private const string Json = "{\"Description\": 2}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _service = _mocker.Create<NotificationService>();
        }

        [Test]
        public void TestNotifySnippetCreatedShouldNotifyNotificationSystem()
        {
            _service.NotifySnippetCreated("Snippet description", new DateTime());

            _mocker.GetMock<IWebClientWrapper>()
                .Verify(p => p.Post(Address, Json),
                    Times.Once);
        }
    }
}
