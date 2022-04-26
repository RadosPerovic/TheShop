using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Configurations
{
    public class SupplierRecordConfiguration : IEntityTypeConfiguration<SupplierRecord>
    {
        public void Configure(EntityTypeBuilder<SupplierRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
