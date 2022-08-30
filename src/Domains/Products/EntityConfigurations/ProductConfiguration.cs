namespace ECommerce.Entities.Configurations
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Products");

            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.Property(p => p.NameSecondLanguage).IsRequired().HasMaxLength(400);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(5000);
            builder.Property(p => p.DescriptionSecondLanguage).IsRequired().HasMaxLength(5000);

        }
    }
}