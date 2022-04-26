using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheShop.Core.Domain;
using TheShop.Core.Domain.Entities;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Repositories.Base
{
    public abstract class ReadOnlyRepository<TEntity, TRecord> : IReadOnlyRepository<TEntity>
        where TEntity : class, IEntity
        where TRecord : class, IMapFrom<TEntity>, IRecord<int>
    {
        protected DatabaseContext _context;
        protected DbSet<TRecord> _dbSet;
        protected readonly IMapper _mapper;

        public ReadOnlyRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TRecord>();
        }

        protected abstract IQueryable<TRecord> BaseQuery { get; }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var record = await BaseQuery.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            return _mapper.Map<TEntity>(record);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var records = await BaseQuery.AsNoTracking().ToListAsync();

            return _mapper.Map<List<TEntity>>(records);
        }
    }
}
