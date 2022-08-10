namespace ECommerce
{
    using ECommerce.Common;

    public class ProductUnitOfWork : BaseUnitOfWork<Product>, IProductUnitOfWork
    {
        public ProductUnitOfWork(IProductRepository repsitory) : base(repsitory)
        {
        }
    }
}