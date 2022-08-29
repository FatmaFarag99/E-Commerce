namespace ECommerce.MapperProfiles
{
    using AutoMapper;

    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                /*.ForMember(dest => dest.Products, options => options.MapFrom(src => src.ProductCategories))*/.ReverseMap();
        }
    }

    //public class ProductCategoryMapperProfile : Profile
    //{
    //    public ProductCategoryMapperProfile()
    //    {
    //        CreateMap<ProductCategory, ProductCategoryViewModel>()
    //            .ForMember(dest => dest.Products, options => options.MapFrom(src => src.ProductCategories)).ReverseMap();
    //    }
    //}
}