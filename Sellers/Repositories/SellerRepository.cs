namespace Sellers.Repositories;

using ECommerce.Common;
using Microsoft.EntityFrameworkCore;
using Sellers.Entities;
public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(DbContext dbContext) : base(dbContext)
    {
    }
    public override async Task<List<Seller>> GetAllAsync()
    {
        return await _table
            .Include(c => c.Products)
            .ToListAsync();
    }

    public override async Task<Seller> GetByIdAsync(Guid id)
    {
        return await _table
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}