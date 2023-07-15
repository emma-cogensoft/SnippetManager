using System;
using System.Threading.Tasks;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Infrastructure.Network;

namespace Cogensoft.SnippetManager.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        // Note: these are hard coded to keep the demo simple
        private const string SnippetTemplate = "http://abc123.com/notification/snippets/{0}/notifysnippetcreated/";
        private const string JsonTemplate = "{{\"snippet\": \"{0}\"}}";

        private readonly IWebClientWrapper _client;

        public NotificationService(IWebClientWrapper client)
        {
            _client = client;
        }

        public async Task NotifySnippetCreatedAsync(int snippetId, string description)
        {
            Console.WriteLine($"Snippet created: {description} {snippetId}");
            
            var address = string.Format(SnippetTemplate, snippetId);
            var json = string.Format(JsonTemplate, description);

            await _client.PostAsync(address, json);
        }
    }
}
