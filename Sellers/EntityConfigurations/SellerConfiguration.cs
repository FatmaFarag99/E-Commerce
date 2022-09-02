namespace Sellers.EntityConfigurations
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sellers.Entities;

    public class SellerConfiguration : BaseEntityConfiguration<Seller>
    {
        public override void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);

        }
    }
}
