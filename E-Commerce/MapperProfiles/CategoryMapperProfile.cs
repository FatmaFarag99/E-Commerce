namespace ECommerce
{
    using AutoMapper;

    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}