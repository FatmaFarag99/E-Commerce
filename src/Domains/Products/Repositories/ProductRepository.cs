namespace ECommerce
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            return await _table
                .Include(p => p.ProductCategories)
                .ToListAsync();
        }
    }
}