namespace Sellers.UnitOfWorks
{
    using ECommerce.Common;
    using Sellers.Entities;
    using Sellers.Repositories;

    public class SellerUnitOfWork : BaseUnitOfWork<Seller>, ISellerUnitOfWork
    {
        public SellerUnitOfWork(ISellerRepository repsitory) : base(repsitory)
        {
        }
    }


}