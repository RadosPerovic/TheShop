using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Configurations
{
    public class ArticleRecordConfiguration : IEntityTypeConfiguration<ArticleRecord>
    {
        public void Configure(EntityTypeBuilder<ArticleRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(100);
        }
    }
}
