namespace Orders.UnitOfWorks
{
    using ECommerce.Common;
    using Orders.Entities;
    using Orders.Repositories;

    public class OrderUnitOfWork : BaseUnitOfWork<Order>, IOrderUnitOfWork
    {
        public OrderUnitOfWork(IOrderRepository repsitory) : base(repsitory)
        {
        }
    }
}
