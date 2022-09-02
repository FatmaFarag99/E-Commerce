namespace Customers.EntityConfigurations
{
    using Customers.Entities;
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);
            builder.HasMany(c => c.Orders).WithOne().HasForeignKey(e => e.CustomerId);

        }
    }
}
