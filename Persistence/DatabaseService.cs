using System.Reflection;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;

namespace Cogensoft.SnippetManager.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<Snippet> Snippets { get; set; }
        
        public DatabaseService() : base(){}

        public DatabaseService(DbContextOptions<DatabaseService> options)
            : base(options)
        {
        }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
