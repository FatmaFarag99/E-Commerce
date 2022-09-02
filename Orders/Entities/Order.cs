namespace Orders.Entities
{
    using ECommerce.Common;

    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid CustomerId { get; set; }

    }
}
