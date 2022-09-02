namespace ECommerce
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}