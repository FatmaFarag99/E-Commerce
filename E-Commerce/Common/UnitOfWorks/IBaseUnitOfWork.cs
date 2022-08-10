namespace ECommerce.Common.UnitOfWorks
{
    using System.Linq.Expressions;

    public interface IBaseUnitOfWork<BaseEntity>
    {
        Task<IEnumerable<BaseEntity>> ReadAllAsync();
        Task<IEnumerable<BaseEntity>> ReadByExpressionAsync(Expression<Func<BaseEntity, bool>> expression);
        Task<BaseEntity> ReadByIdAsync(Guid id);
        Task<BaseEntity> CreateAsync(BaseEntity entity);
        Task<BaseEntity> UpdateAsync(BaseEntity entity);
        Task<BaseEntity> DeleteByIdAsync(Guid id);
    }
}
