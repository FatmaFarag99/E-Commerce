namespace ECommerce.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseUnitOfWork : IBaseUnitOfWork<BaseEntity>
    {
        private readonly IBaseRepository<BaseEntity> _repository;
        protected readonly ApplicationDbContext _context;

        public BaseUnitOfWork(IBaseRepository<BaseEntity> repository)
        {
            _repository = repository;
            _context = repository.Context;
        }
        public virtual async Task<IEnumerable<BaseEntity>> ReadAllAsync()
        {
            IEnumerable<BaseEntity> entities = await _repository.GetAllAsync();
            return entities;
        }

        public virtual async Task<IEnumerable<BaseEntity>> ReadByExpressionAsync(Expression<Func<BaseEntity, bool>> expression)
        {
            IEnumerable<BaseEntity> entities = await _repository.GetByExprissionAsync(expression);
            return entities;
        }

        public virtual async Task<BaseEntity> ReadByIdAsync(Guid id)
        {
            BaseEntity entity = await _repository.GetByIdAsync(id);
            return entity;
        }
        public virtual async Task<BaseEntity> CreateAsync(BaseEntity entity)
        {
            BaseEntity entityFromDb = await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entityFromDb;
        }
        public virtual async Task<BaseEntity> UpdateAsync(BaseEntity entity)
        {
            BaseEntity entityFromDb = await _repository.EditAsync(entity);
            await _context.SaveChangesAsync();

            return entityFromDb;
        }
        public virtual async Task<BaseEntity> DeleteByIdAsync(Guid id)
        {
            BaseEntity entityFromDb = await _repository.DeleteAsync(id);
            await _context.SaveChangesAsync();

            return entityFromDb;
        }
       
    }
}