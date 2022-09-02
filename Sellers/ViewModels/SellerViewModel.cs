namespace Sellers.ViewModels
{
    using ECommerce;
    using ECommerce.Common;
    public class SellerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
