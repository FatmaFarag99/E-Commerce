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
        //public CategoriesController(ICategoryUnitOfWork unitOfWork, IMapper mapper, IValidator<CategoryViewModel> validator)
        public CategoriesController(IBaseUnitOfWork<Category> unitOfWork, IMapper mapper, IValidator<CategoryViewModel> validator)
            : base(unitOfWork, mapper, validator)
        {
        }

        [HttpGet]
        public override async Task<IEnumerable<CategoryViewModel>> Get()
        {
            List<Category> categories = await _unitOfWork.ReadAsync();
            List<CategoryViewModel> categoryViewModels = categories.Select(category =>
            {
                CategoryViewModel categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                categoryViewModel.Products = category.ProductCategories?.Select(pc => _mapper.Map<ProductViewModel>(pc.Product)).ToList();
                return categoryViewModel;
            }).ToList();

            return categoryViewModels;
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(Guid id)
        {
            Category category = await _unitOfWork.ReadByIdAsync(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

            categoryViewModel.Products = category.ProductCategories?.Select(pc => _mapper.Map<ProductViewModel>(pc.Product)).ToList();

            return Ok(categoryViewModel);
        }
    }
}