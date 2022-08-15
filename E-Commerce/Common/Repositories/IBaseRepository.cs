namespace ECommerce.Common.Repositories
{
    using ECommerce.Common.Entities;
    using System.Linq.Expressions;

    public interface IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        ApplicationDbContext Context { get; }
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByExprissionAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Guid id);
        Task<TEntity> EditAsync(TEntity entity);
    }
}
