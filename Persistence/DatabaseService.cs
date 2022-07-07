using System.Data.Entity;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Domain.Snippets;
using Cogensoft.SnippetManager.Persistence.Snippets;

namespace Cogensoft.SnippetManager.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<Snippet> Snippets { get; set; }

        public DatabaseService() : base("SnippetManager")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new SnippetConfiguration());
        }
    }
}
