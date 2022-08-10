namespace ECommerce.Common.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public interface IBaseGetController
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetByIdAsync(Guid id);
    }
}
