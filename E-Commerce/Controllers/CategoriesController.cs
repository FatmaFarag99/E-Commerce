namespace ECommerce
{
    using AutoMapper;
    using ECommerce.Common;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, CategoryViewModel>
    {
        public CategoriesController(ICategoryUnitOfWork unitOfWork, IMapper mapper, IValidator<CategoryViewModel> validator)
            : base(unitOfWork, mapper, validator)
        {
        }
    }
}