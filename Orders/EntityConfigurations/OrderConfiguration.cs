namespace Orders.EntityConfigurations
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Orders.Entities;

    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);

        }
    }
}
