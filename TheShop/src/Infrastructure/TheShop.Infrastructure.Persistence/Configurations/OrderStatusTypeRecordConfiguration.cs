using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Configurations
{
    public class OrderStatusTypeRecordConfiguration : IEntityTypeConfiguration<OrderStatusTypeRecord>
    {
        public void Configure(EntityTypeBuilder<OrderStatusTypeRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();
        }
    }
}
