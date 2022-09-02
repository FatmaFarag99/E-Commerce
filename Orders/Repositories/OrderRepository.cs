namespace Orders.Repositories
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    using Orders.Entities;

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
