namespace ECommerce.Common
{
    using System.Linq.Expressions;

    public interface IBaseUnitOfWork<T>
        where T : BaseEntity
    {
        Task<List<T>> ReadAsync();
        Task<T> ReadByIdAsync(Guid id);
        Task<List<T>> ReadByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
    }

    public class BaseUnitOfWork<T> : IBaseUnitOfWork<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repsitory;

        public BaseUnitOfWork(IBaseRepository<T> repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<List<T>> ReadAsync()
        {
            return await _repsitory.GetAllAsync();
        }

        public async Task<T> ReadByIdAsync(Guid id)
        {
            return await _repsitory.GetByIdAsync(id);
        }

        public async Task<List<T>> ReadByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _repsitory.GetByExpressionAsync(expression);
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity = await _repsitory.AddAsync(entity);
            await _repsitory.DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity = await _repsitory.EditAsync(entity);
            await _repsitory.DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            T entity = await _repsitory.DeleteAsync(id);
            await _repsitory.DbContext.SaveChangesAsync();
            return entity;
        }
    }
}