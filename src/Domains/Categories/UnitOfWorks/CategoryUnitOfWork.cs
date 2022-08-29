namespace ECommerce
{
    using ECommerce.Common;

    public class CategoryUnitOfWork : BaseUnitOfWork<Category>, ICategoryUnitOfWork
    {
        public CategoryUnitOfWork(ICategoryRepository repsitory) : base(repsitory)
        {
        }
    }
}