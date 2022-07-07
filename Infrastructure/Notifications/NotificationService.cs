using System;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Infrastructure.Network;

namespace Cogensoft.SnippetManager.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        // Note: these are hard coded to keep the demo simple
        private const string AddressTemplate = "http://abc123.com/inventory/products/{0}/notifysaleoccured/";
        private const string JsonTemplate = "{{\"snippet\": {0}}}";

        private readonly IWebClientWrapper _client;

        public NotificationService(IWebClientWrapper client)
        {
            _client = client;
        }

        public void NotifySnippetCreated(string description, DateTime date)
        {
            Console.WriteLine($"Snippet created: {description} {date}");
        }
    }
}
