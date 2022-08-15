namespace ECommerce.Common.UnitOfWorks
{
    using ECommerce.Common.Entities;
    using System.Linq.Expressions;

    public interface IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> ReadAllAsync();
        Task<IEnumerable<TEntity>> ReadByExpressionAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> ReadByIdAsync(Guid id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteByIdAsync(Guid id);
    }
}
