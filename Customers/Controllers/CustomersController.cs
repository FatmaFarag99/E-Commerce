namespace Customers.Controllers
{
    using AutoMapper;
    using Customers.Entities;
    using Customers.ViewModels;
    using ECommerce.Common;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer, CustomerViewModel>
    {
        public CustomersController(IBaseUnitOfWork<Customer> unitOfWork, IMapper mapper, IValidator<CustomerViewModel> validator) 
            : base(unitOfWork, mapper, validator)
        {
        }

    }
}
