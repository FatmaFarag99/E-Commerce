namespace Orders.ViewModels
{
    using ECommerce.Common;
    public class OrderViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
    }
}