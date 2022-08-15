namespace ECommerce.Common.Controllers
{
    using ECommerce.Common.Entities;
    using ECommerce.Common.UnitOfWorks;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class BaseGetController<TEntity> : ControllerBase, IBaseGetController 
        where TEntity : BaseEntity
    {
        private readonly IBaseUnitOfWork<TEntity> _unitOfWork;

        public BaseGetController(IBaseUnitOfWork<TEntity> unitOfWork) => _unitOfWork = unitOfWork;
      
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<TEntity> viewModels = await _unitOfWork.ReadAllAsync();
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(Guid id)
        {
            TEntity viewModel = await _unitOfWork.ReadByIdAsync(id);
            return Ok(viewModel);
        }
    }
}