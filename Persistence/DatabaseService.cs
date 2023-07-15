using System.Reflection;
using System.Threading.Tasks;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;

namespace Cogensoft.SnippetManager.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<Snippet> Snippets { get; set; }
        
        public DatabaseService() {}

        public DatabaseService(DbContextOptions<DatabaseService> options)
            : base(options)
        {
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
