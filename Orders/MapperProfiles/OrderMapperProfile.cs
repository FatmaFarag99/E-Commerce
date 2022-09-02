namespace Orders.MapperProfiles
{
    using AutoMapper;
    using Orders.Entities;
    using Orders.ViewModels;

    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
