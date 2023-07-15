using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cogensoft.SnippetManager.Infrastructure.Network
{
    public class WebClientWrapper : IWebClientWrapper
    {
        public Task PostAsync(string address, string json)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");

            // Note: This next line is commented out to prevent an
            // Note: actual HTTP call, since this is just a demo app.

            // client.UploadString(address, "POST", json);
            return Task.CompletedTask;
        }
    }
}
