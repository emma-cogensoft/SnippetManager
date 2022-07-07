using System;

namespace Cogensoft.SnippetManager.Application.Interfaces
{
    public interface INotificationService
    {
        void NotifySnippetCreated(string description, DateTime date);
    }
}
