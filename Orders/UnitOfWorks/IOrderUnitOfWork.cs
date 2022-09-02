namespace Orders.UnitOfWorks
{
    using ECommerce.Common;
    using Orders.Entities;

    public interface IOrderUnitOfWork : IBaseUnitOfWork<Order>
    {
    } 
}
