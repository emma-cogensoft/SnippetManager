using System.Data.Entity.ModelConfiguration;
using Cogensoft.SnippetManager.Domain.Snippets;

namespace Cogensoft.SnippetManager.Persistence.Snippets
{
    public class SnippetConfiguration
           : EntityTypeConfiguration<Snippet>
    {
        public SnippetConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Date)
                .IsRequired();
            
            Property(p => p.Description)
                .IsRequired();
            
            Property(p => p.SnippetBody)
                .IsRequired();
        }
    }
}
