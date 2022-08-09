namespace ECommerce.Common
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseRepository : IBaseRepository<BaseEntity>
    {
        public ApplicationDbContext Context { get;}
        protected DbSet<BaseEntity> _table;
        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            _table = context.Set<BaseEntity>();
        }

        public virtual async Task<IEnumerable<BaseEntity>> GetAllAsync() => await _table.OrderBy(e => e.DisplayOrder).ToListAsync();



        public virtual async Task<IEnumerable<BaseEntity>> GetByExprissionAsync(System.Linq.Expressions.Expression<Func<BaseEntity, bool>> expression)
        {
            return await _table.Where(expression).OrderBy(e => e.DisplayOrder).ToListAsync();
        }

        public virtual async Task<BaseEntity> GetByIdAsync(Guid id) => await _table.Where(e => e.Id == id).OrderBy(e => e.DisplayOrder).FirstOrDefaultAsync();
        

        public virtual async Task<BaseEntity> AddAsync(BaseEntity entity)
        {
            var maxDisplayOrder = GetMaxDisplayOrder();
            entity.DisplayOrder = maxDisplayOrder++;
            return (await _table.AddAsync(entity)).Entity;

        }

        public virtual async Task<BaseEntity> DeleteAsync(Guid id)
        {
            BaseEntity entityFromDb = await GetByIdAsync(id);
            if (entityFromDb == null)
                throw new Exception("Entity dosn't exist in database");

            _table.Remove(entityFromDb);

            return entityFromDb;
        }

        public virtual async Task<BaseEntity> EditAsync(BaseEntity entity)
        {
            BaseEntity entityFromDb = await GetByIdAsync(entity.Id);
            if (entityFromDb == null)
                return await AddAsync(entity);
            else
                return _table.Update(entity).Entity;
        }

        public virtual int GetMaxDisplayOrder()
        {
            if(((IQueryable<BaseEntity>) _table).Any())
            {
                return ((IQueryable<BaseEntity>)_table).Max(e => e.DisplayOrder);
            }
            return 0;
        }
      
    }
}
