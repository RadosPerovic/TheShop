using Microsoft.EntityFrameworkCore;
using TheShop.Core.Domain.Enums;
using TheShop.Infrastructure.Persistence.Configurations;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<CustomerRecord> Customers { get; set; }
        public virtual DbSet<SupplierRecord> Suppliers { get; set; }
        public virtual DbSet<ArticleRecord> Articles { get; set; }
        public virtual DbSet<OrderStatusTypeRecord> OrderStatusTypes { get; set; }
        public virtual DbSet<OrderRecord> Orders { get; set; }
        public virtual DbSet<OrderItemRecord> OrderItems { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfiguration(modelBuilder);
            Seed(modelBuilder);
        }

        private void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerRecordConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierRecordConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusTypeRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemRecordConfiguration());
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            SeedEnumRecords<OrderStatusTypeRecord, OrderStatusType>(modelBuilder, e => new OrderStatusTypeRecord { Id = e, Name = e.ToString() });
        }

        private void SeedRecords<TRecord>(ModelBuilder modelBuilder, List<TRecord> records) where TRecord : class
        {
            modelBuilder.Entity<TRecord>().HasData(records);
        }

        private void SeedEnumRecords<TRecord, TEnum>(ModelBuilder modelBuilder, Func<TEnum, TRecord> converter) where TRecord : class
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var records = values.Select(converter).ToList();

            SeedRecords(modelBuilder, records);
        }
    }
}
