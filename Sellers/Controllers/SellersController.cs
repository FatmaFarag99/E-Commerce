namespace Sellers.Controllers
{
    using AutoMapper;
    using ECommerce.Common;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;
    using Sellers.Entities;
    using Sellers.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : BaseController<Seller, SellerViewModel>
    {
        public SellersController(IBaseUnitOfWork<Seller> unitOfWork, IMapper mapper, IValidator<SellerViewModel> validator) 
            : base(unitOfWork, mapper, validator)
        {
        }

    }
}