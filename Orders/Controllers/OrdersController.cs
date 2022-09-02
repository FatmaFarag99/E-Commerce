namespace Orders.Controllers
{
    using AutoMapper;
    using Orders.Entities;
    using Orders.ViewModels;
    using ECommerce.Common;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<Order, OrderViewModel>
    {
        public OrdersController(IBaseUnitOfWork<Order> unitOfWork, IMapper mapper, IValidator<OrderViewModel> validator) 
            : base(unitOfWork, mapper, validator)
        {
        }

    }
}
