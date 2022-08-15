namespace ECommerce.Common.Repositories
{
    using ECommerce.Common.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        public ApplicationDbContext Context { get; }
        protected DbSet<TEntity> _table;
        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            _table = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _table.OrderBy(e => e.DisplayOrder).ToListAsync();



        public virtual async Task<IEnumerable<TEntity>> GetByExprissionAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return await _table.Where(expression).OrderBy(e => e.DisplayOrder).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id) => await _table.Where(e => e.Id == id).OrderBy(e => e.DisplayOrder).FirstOrDefaultAsync();


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var maxDisplayOrder = GetMaxDisplayOrder();
            entity.DisplayOrder = maxDisplayOrder++;
            return (await _table.AddAsync(entity)).Entity;

        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            TEntity entityFromDb = await GetByIdAsync(id);
            if (entityFromDb == null)
                throw new Exception("Entity dosn't exist in database");

            _table.Remove(entityFromDb);

            return entityFromDb;
        }

        public virtual async Task<TEntity> EditAsync(TEntity entity)
        {
            TEntity entityFromDb = await GetByIdAsync(entity.Id);
            if (entityFromDb == null)
                return await AddAsync(entity);
            else
                return _table.Update(entity).Entity;
        }

        public virtual int GetMaxDisplayOrder()
        {
            if (_table.Any())
            {
                return _table.Max(e => e.DisplayOrder);
            }
            return 0;
        }

    }
}
