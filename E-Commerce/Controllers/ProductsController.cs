namespace ECommerce
{
    using AutoMapper;
    using ECommerce.Common;
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController<TEntity, TViewModel> : ControllerBase
        where TEntity : BaseEntity
        where TViewModel : BaseViewModel
    {
        private readonly IBaseUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<TViewModel> _validator;

        public BaseController(IBaseUnitOfWork<TEntity> unitOfWork, IMapper mapper, IValidator<TViewModel> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> Get()
        {
            List<TEntity> entities = await _unitOfWork.ReadAsync();
            return entities.Select(product => _mapper.Map<TViewModel>(product));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            TEntity product = await _unitOfWork.ReadByIdAsync(id);
            var productViewModel = _mapper.Map<TViewModel>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TViewModel productViewModel)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            var product = _mapper.Map<TEntity>(productViewModel);

            product = await _unitOfWork.CreateAsync(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, _mapper.Map<TViewModel>(product));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TViewModel productViewModel)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            var product = _mapper.Map<TEntity>(productViewModel);

            product = await _unitOfWork.UpdateAsync(product);

            return Ok(_mapper.Map<TViewModel>(product));
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _unitOfWork.DeleteAsync(id);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product, ProductViewModel>
    {
        public ProductsController(IProductUnitOfWork unitOfWork, IMapper mapper, IValidator<ProductViewModel> validator)
            : base(unitOfWork, mapper, validator)
        {
        }

        //private readonly IProductUnitOfWork _productUnitOfWork;
        //private readonly IMapper _mapper;
        //private readonly IValidator<ProductViewModel> _validator;

        //public ProductsController(IProductUnitOfWork productUnitOfWork, IMapper mapper, IValidator<ProductViewModel> validator)
        //{
        //    _productUnitOfWork = productUnitOfWork;
        //    _mapper = mapper;
        //    _validator = validator;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<ProductViewModel>> Get()
        //{
        //    List<Product> entities = await _productUnitOfWork.ReadAsync();
        //    return entities.Select(product => _mapper.Map<ProductViewModel>(product));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    Product product = await _productUnitOfWork.ReadByIdAsync(id);
        //    ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);
        //    return Ok(productViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] ProductViewModel productViewModel)
        //{
        //    ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
        //    if (!validationResult.IsValid)
        //        return BadRequest(new { errors = validationResult.Errors });

        //    var product = _mapper.Map<Product>(productViewModel);

        //    product = await _productUnitOfWork.CreateAsync(product);

        //    return CreatedAtAction(nameof(Get), new { id = product.Id }, _mapper.Map<ProductViewModel>(product));
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] ProductViewModel productViewModel)
        //{
        //    ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
        //    if (!validationResult.IsValid)
        //        return BadRequest(new { errors = validationResult.Errors });

        //    var product = _mapper.Map<Product>(productViewModel);

        //    product = await _productUnitOfWork.UpdateAsync(product);

        //    return AcceptedAtAction(nameof(Get), new { id = product.Id },  _mapper.Map<ProductViewModel>(product));
        //}

        //[HttpDelete("{id}")]
        //public async Task Delete(Guid id)
        //{
        //    await _productUnitOfWork.DeleteAsync(id);
        //}
    }
}