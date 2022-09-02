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
}