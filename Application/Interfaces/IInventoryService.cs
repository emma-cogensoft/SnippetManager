namespace Cogensoft.SnippetManager.Application.Interfaces
{
    public interface INotificationService
    {
        void NotifySnippetCreated(int snippetId, string description);
    }
}
