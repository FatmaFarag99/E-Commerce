namespace ECommerce.Common
{
    using System.Linq.Expressions;

    public interface IBaseRepository<BaseEntity> 
    {
        ApplicationDbContext Context { get; }
        Task<IEnumerable<BaseEntity>> GetAllAsync();
        Task<IEnumerable<BaseEntity>> GetByExprissionAsync(Expression<Func<BaseEntity, bool>> expression);
        Task<BaseEntity> GetByIdAsync(Guid id);
        Task<BaseEntity> AddAsync(BaseEntity entity);
        Task<BaseEntity> DeleteAsync(Guid id);
        Task<BaseEntity> EditAsync(BaseEntity entity);
    }
}
