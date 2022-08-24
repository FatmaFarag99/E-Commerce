namespace ECommerce
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public interface ICategoryRepository
    {
        ApplicationDbContext DbContext { get; }

        Task<Category> AddAsync(Category product);
        Task<Category> DeleteAsync(Guid id);
        Task<Category> EditAsync(Category product);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetByExprissionAsync(Expression<Func<Category, bool>> expression);
        Task<Category> GetByIdAsync(Guid id);
    }

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}