namespace Customers.Entities
{
    using ECommerce.Common;
    using Orders.Entities;

    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactAddress { get; set; }
        public List<Order> Orders { get; set; }

    }
}
