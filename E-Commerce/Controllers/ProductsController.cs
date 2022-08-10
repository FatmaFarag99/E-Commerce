// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce
{
    using AutoMapper;
    using ECommerce.Common;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product, ProductViewModel>
    {
        public ProductsController(IProductUnitOfWork unitOfWork, IMapper mapper, IValidator<ProductViewModel> validator) 
            : base(unitOfWork, mapper, validator)
        {
        }
    }
}