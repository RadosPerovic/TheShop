using AutoMapper;
using TheShop.Core.Domain;
using TheShop.Core.Domain.Entities;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Repositories.Base
{
    public abstract class Repository<TEntity, TRecord> : ReadOnlyRepository<TEntity, TRecord>, IRepository<TEntity>
        where TEntity : class, IEntity
        where TRecord : class, IMapFrom<TEntity>, IRecord<int>
    {
        protected Repository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual Task AddAsync(TEntity entity)
        {
            var record = _mapper.Map<TRecord>(entity);
            _dbSet.Add(record);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            var record = _mapper.Map<TRecord>(entity);
            _dbSet.Update(record);
            return Task.CompletedTask;
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
