using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Api.Persistence.Configurations
{
    public class TodoConfiguration : EntityTypeConfigurationBase<Model.Todo>
    {
        public override void ConfigureCore(EntityTypeBuilder<Model.Todo> builder)
        {
            builder.ToTable("Todo", "Planning");
            builder.Property(x => x.Description);
            builder.Property(x => x.Summary);
            builder.Property(x => x.IsDone);
            builder.OwnsOne(x => x.Interval);
        }
    }
}
