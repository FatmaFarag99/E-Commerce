namespace ECommerce
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}