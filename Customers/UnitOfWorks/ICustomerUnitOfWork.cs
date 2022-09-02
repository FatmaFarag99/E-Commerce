namespace Customers.UnitOfWorks
{
    using Customers.Entities;
    using ECommerce.Common;
    public interface ICustomerUnitOfWork : IBaseUnitOfWork<Customer>
    {
    } 
}
