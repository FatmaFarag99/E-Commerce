namespace ECommerce.MapperProfiles
{
    using AutoMapper;

    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }

    public class ProductCategoryMapperProfile : Profile
    {
        public ProductCategoryMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
        }
    }
}