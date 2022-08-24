namespace ECommerce.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbContext DbContext { get; }

        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(Guid id);
        Task<T> EditAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        public DbContext DbContext { get; }
        private readonly DbSet<T> _table;

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _table = DbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id) => await _table.FirstOrDefaultAsync(p => p.Id == id);
        public virtual async Task<List<T>> GetAllAsync() => await _table.ToListAsync();
        public virtual async Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression)
            => await _table.Where(expression).ToListAsync();

        public virtual async Task<T> AddAsync(T entity)
        {
            return (await _table.AddAsync(entity)).Entity;
        }
        public virtual async Task<T> EditAsync(T entity)
        {
            if (!await IsExists(entity))
                throw new Exception("Entity dosn't exist in database");

            return _table.Update(entity).Entity;
        }
        public virtual async Task<T> DeleteAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);
            if (entity is null)
                throw new Exception("Entity dosn't exist in database");

            _table.Remove(entity);

            return entity;
        }


        protected async Task<bool> IsExists(Guid entityId)
        {
            return await _table.AnyAsync(p => p.Id == entityId);
        }
        protected async Task<bool> IsExists(T entity)
        {
            return await _table.AnyAsync(p => p.Id == entity.Id);
        }
    }
}