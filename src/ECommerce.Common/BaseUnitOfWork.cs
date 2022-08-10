namespace ECommerce.Common
{
    public interface IBaseUnitOfWork<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T product);
        Task<T> DeleteAsync(Guid productId);
        Task<List<T>> ReadAsync();
        Task<T> ReadByIdAsync(Guid productId);
        Task<T> UpdateAsync(T product);
    }

    public class BaseUnitOfWork<T> : IBaseUnitOfWork<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repsitory;

        public BaseUnitOfWork(IBaseRepository<T> repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task<List<T>> ReadAsync()
        {
            return await _repsitory.GetAllAsync();
        }

        public async Task<T> ReadByIdAsync(Guid productId)
        {
            return await _repsitory.GetByIdAsync(productId);
        }

        public async Task<T> CreateAsync(T product)
        {
            product = await _repsitory.AddAsync(product);
            await _repsitory.DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<T> UpdateAsync(T product)
        {
            product = await _repsitory.EditAsync(product);
            await _repsitory.DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<T> DeleteAsync(Guid productId)
        {
            T product = await _repsitory.DeleteAsync(productId);
            await _repsitory.DbContext.SaveChangesAsync();
            return product;
        }
    }
}