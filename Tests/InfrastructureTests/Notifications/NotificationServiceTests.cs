using Cogensoft.SnippetManager.Infrastructure.Network;
using Cogensoft.SnippetManager.Infrastructure.Notifications;
using Moq;
using Moq.AutoMock;

namespace InfrastructureTests.Notifications
{
    [TestFixture]
    public class NotificationServiceTests
    {
        private NotificationService _service = null!;
        private AutoMocker _mocker = null!;

        private const string Address = "http://abc123.com/notification/snippets/1/notifysnippetcreated/";
        private const string Json = "{\"snippet\": \"Snippet description\"}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _service = _mocker.CreateInstance<NotificationService>();
        }

        [Test]
        public async Task TestNotifySnippetCreatedShouldNotifyNotificationSystem()
        {
            await _service.NotifySnippetCreatedAsync(1, "Snippet description");

            _mocker.GetMock<IWebClientWrapper>()
                .Verify(p => p.PostAsync(Address, Json),
                    Times.Once);
        }
    }
}
