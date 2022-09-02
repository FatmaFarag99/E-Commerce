namespace Customers.ViewModels
{
    using ECommerce.Common;
    using Orders.ViewModels;

    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactAddress { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
