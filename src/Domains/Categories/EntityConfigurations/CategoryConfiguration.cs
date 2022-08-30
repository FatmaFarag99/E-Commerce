namespace ECommerce.Entities
{
    using ECommerce.Common;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);
            builder.Property(c => c.NameSecondLanguage).IsRequired().HasMaxLength(400);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(5000);
            builder.Property(p => p.DescriptionSecondLanguage).IsRequired().HasMaxLength(5000);

           builder.HasMany(p => p.Products).WithOne().HasForeignKey(pc => pc.CategoryId);
        }
    }
}