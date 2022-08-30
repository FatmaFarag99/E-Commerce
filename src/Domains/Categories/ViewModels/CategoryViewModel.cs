namespace ECommerce
{
    using ECommerce.Common;
    using System.Text.Json.Serialization;

    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string NameSecondLanguage { get; set; }
        public string Description { get; set; }
        public string DescriptionSecondLanguage { get; set; }

        //[JsonIgnore]
        //public List<ProductCategoryViewModel> ProductCategories { get; set; }
       // public List<ProductViewModel> Products { get; set; }
    }
}