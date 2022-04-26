namespace TheShop.Core.Domain.Entities
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}
