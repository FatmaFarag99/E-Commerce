namespace Sellers.MapperProfiles
{
    using AutoMapper;
    using Sellers.Entities;
    using Sellers.ViewModels;

    public class SellerMapperProfile : Profile
    {
        public SellerMapperProfile()
        {
            CreateMap<Seller, SellerViewModel>().ReverseMap();
        }
    }
}