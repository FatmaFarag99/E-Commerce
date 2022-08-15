namespace ECommerce.Common.Entities.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.ValueGeneration;

    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property<Guid>(e => e.Id).HasValueGenerator<GuidValueGenerator>();
            builder.Property(e => e.CreationDate).HasDefaultValueSql("getDate()");
            builder.Property(e => e.ConcurrencyStamp).IsRowVersion();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.NameSecondLanguage).IsRequired();
        }
    }
    
}
