namespace TheShop.Core.Domain.Entities
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    { 
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
