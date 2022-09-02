namespace Customers.UnitOfWorks
{
    using Customers.Entities;
    using Customers.Repositories;
    using ECommerce.Common;

    public class CustomerUnitOfWork : BaseUnitOfWork<Customer>, ICustomerUnitOfWork
    {
        public CustomerUnitOfWork(ICustomerRepository repsitory) : base(repsitory)
        {
        }
    }


}
