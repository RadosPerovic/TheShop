using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Configurations
{
    public class OrderItemRecordConfiguration : IEntityTypeConfiguration<OrderItemRecord>
    {
        public void Configure(EntityTypeBuilder<OrderItemRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Total)
                .HasPrecision(18, 2);

            builder.Property(e => e.UnitPrice)
                .HasPrecision(18, 2);

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Article)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supplier)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
