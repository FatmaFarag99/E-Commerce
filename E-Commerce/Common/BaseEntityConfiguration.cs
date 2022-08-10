namespace ECommerce.Common
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            //builder.Property<Guid>(e => e.Id).HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.ConcurrencyStamp).IsRowVersion();
        }
    }
}