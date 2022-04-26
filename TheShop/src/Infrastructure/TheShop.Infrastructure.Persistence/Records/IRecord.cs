namespace TheShop.Infrastructure.Persistence.Records
{
    public interface IRecord<TId>
    {
        TId Id { get; }
    }
}
