using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Api.Model;

namespace Todo.Api.Persistence.Configurations
{
    public abstract class EntityTypeConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created);

            ConfigureCore(builder);
        }

        public abstract void ConfigureCore(EntityTypeBuilder<TEntity> builder);
    }
}