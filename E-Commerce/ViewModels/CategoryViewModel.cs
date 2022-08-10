namespace ECommerce
{
    using ECommerce.Common;

    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string NameSecondLanguage { get; set; }

        public string Description { get; set; }
        public string DescriptionSecondLanguage { get; set; }

        public List<Product> Products { get; set; }
    }
}
