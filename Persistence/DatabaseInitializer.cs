using System;
using System.Data.Entity;
using Cogensoft.SnippetManager.Domain.Snippets;

namespace Cogensoft.SnippetManager.Persistence
{
    public class DatabaseInitializer 
        : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);
            
            CreateSnippets(database);
        }

        private void CreateSnippets(DatabaseService database)
        {
            database.Snippets.Add(new Snippet
            {
                Date = DateTime.Now.Date.AddDays(-3),
                Description = "Seed description",
                SnippetBody = "Seed body"
            });

            database.SaveChanges();
        }
    }
}
