namespace ECommerce.Common.UnitOfWorks
{
    using ECommerce.Common.Entities;
    using ECommerce.Common.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        protected readonly ApplicationDbContext _context;

        public BaseUnitOfWork(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
            _context = repository.Context;
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync();
            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> ReadByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            IEnumerable<TEntity> entities = await _repository.GetByExprissionAsync(expression);
            return entities;
        }

        public virtual async Task<TEntity> ReadByIdAsync(Guid id)
        {
            TEntity entity = await _repository.GetByIdAsync(id);
            return entity;
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            TEntity entityFromDb = await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entityFromDb;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity entityFromDb = await _repository.EditAsync(entity);
            await _context.SaveChangesAsync();

            return entityFromDb;
        }
        public virtual async Task<TEntity> DeleteByIdAsync(Guid id)
        {
            TEntity entityFromDb = await _repository.DeleteAsync(id);
            await _context.SaveChangesAsync();

            return entityFromDb;
        }

    }
}