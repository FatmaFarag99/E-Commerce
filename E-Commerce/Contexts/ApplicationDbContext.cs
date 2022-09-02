namespace ECommerce
{
    using Customers.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Orders.Entities;
    using Sellers.Entities;

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Product).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Category).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Customer).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Order).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Seller).Assembly);
        }
    }
}