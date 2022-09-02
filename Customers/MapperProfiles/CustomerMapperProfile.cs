namespace Customers.MapperProfiles
{
    using AutoMapper;
    using Customers.Entities;
    using Customers.ViewModels;

    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
        }
    }
}
