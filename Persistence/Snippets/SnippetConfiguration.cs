using Cogensoft.SnippetManager.Domain.Snippets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cogensoft.SnippetManager.Persistence.Snippets
{
    public class SnippetConfiguration : IEntityTypeConfiguration<Snippet>
    {
        public void Configure(EntityTypeBuilder<Snippet> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date)
                .IsRequired();
            
            builder.Property(p => p.Description)
                .IsRequired();
            
            builder.Property(p => p.SnippetBody)
                .IsRequired();
        }
    }
}
