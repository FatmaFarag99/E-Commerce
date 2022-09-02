namespace Customers.Repositories
{
    using Customers.Entities;
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Customer>> GetAllAsync()
        {
            return await _table
                .Include(c => c.Orders)
                .ToListAsync();
        }

        public override async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _table
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
