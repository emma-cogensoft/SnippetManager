using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet.Factory;
using Cogensoft.SnippetManager.Common.Dates;

namespace Cogensoft.SnippetManager.Application.Snippets.Commands.CreateSnippet
{
    public class CreateSnippetCommand
        : ICreateSnippetCommand
    {
        private readonly IDateService _dateService;
        private readonly IDatabaseService _database;
        private readonly ISnippetFactory _factory;
        private readonly INotificationService _notificationService;

        public CreateSnippetCommand(
            IDateService dateService,
            IDatabaseService database,
            ISnippetFactory factory,
            INotificationService notificationService)
        {
            _dateService = dateService;
            _database = database;
            _factory = factory;
            _notificationService = notificationService;
        }

        public void Execute(CreateSnippetModel model)
        {
            var date = _dateService.GetDate();

            var snippet = _factory.Create(
                date,
                model.Description, model.SnippetBody);

            _database.Snippets.Add(snippet);

            _database.Save();

            _notificationService.NotifySnippetCreated(snippet.Description, snippet.Date);
        }
    }
}
