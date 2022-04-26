namespace TheShop.Infrastructure.Persistence.Records
{
    public class Record<TId> : IRecord<TId>
    {
        public TId Id { get; set; }
    }
}
