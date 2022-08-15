namespace ECommerce.Common.Controllers
{
    using ECommerce.Common.Entities;
    using Microsoft.AspNetCore.Mvc;

    public interface IBaseController<TEntity> : IBaseGetController  where TEntity : BaseEntity
    {
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> Post([FromBody] TEntity entity);
        Task<IActionResult> Put([FromBody] TEntity entity);
    }
}
