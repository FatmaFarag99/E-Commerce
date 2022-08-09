namespace ECommerce.Common
{
    using System.Linq.Expressions;

    public interface IBaseUnitOfWork<T> where T : class
    {
        Task<IEnumerable<T>> ReadAllAsync();
        Task<IEnumerable<T>> ReadByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> ReadByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteByIdAsync(Guid id);
    }
}
