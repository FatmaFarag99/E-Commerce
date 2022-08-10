namespace ECommerce.Common.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public interface IBaseController<BaseEntity> : IBaseGetController
    {
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> Post([FromBody] BaseEntity entity);
        Task<IActionResult> Put([FromBody] BaseEntity entity);
    }
}
