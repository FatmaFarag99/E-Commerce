namespace ECommerce.Common.Controllers
{
    using ECommerce.Common.UnitOfWorks;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class BaseGetController<BaseEntity> : ControllerBase, IBaseGetController
    {
        private readonly IBaseUnitOfWork<BaseEntity> _unitOfWork;

        public BaseGetController(IBaseUnitOfWork<BaseEntity> unitOfWork) => _unitOfWork = unitOfWork;
      
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<BaseEntity> viewModels = await _unitOfWork.ReadAllAsync();
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(Guid id)
        {
            BaseEntity viewModel = await _unitOfWork.ReadByIdAsync(id);
            return Ok(viewModel);
        }
    }
}