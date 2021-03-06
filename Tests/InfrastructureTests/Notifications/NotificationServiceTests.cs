using Cogensoft.SnippetManager.Infrastructure.Network;
using Cogensoft.SnippetManager.Infrastructure.Notifications;
using Moq;
using Moq.AutoMock;

namespace InfrastructureTests.Notifications
{
    [TestFixture]
    public class NotificationServiceTests
    {
        private NotificationService _service;
        private AutoMocker _mocker;

        private const string Address = "http://abc123.com/notification/snippets/1/notifysnippetcreated/";
        private const string Json = "{\"snippet\": \"Snippet description\"}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _service = _mocker.CreateInstance<NotificationService>();
        }

        [Test]
        public void TestNotifySnippetCreatedShouldNotifyNotificationSystem()
        {
            _service.NotifySnippetCreated(1, "Snippet description");

            _mocker.GetMock<IWebClientWrapper>()
                .Verify(p => p.Post(Address, Json),
                    Times.Once);
        }
    }
}
