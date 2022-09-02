namespace Sellers.Entities
{
    using ECommerce;
    using ECommerce.Common;

    public class Seller : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
