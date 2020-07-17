using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Api.Model;

namespace Todo.Api.Persistence.Configurations
{
    public class TodoListConfiguration : EntityTypeConfigurationBase<TodoList>
    {
        public override void ConfigureCore(EntityTypeBuilder<TodoList> builder)
        {
            builder.ToTable("TodoList", "Planning");
            builder.Property(x => x.Name);
            builder.HasMany(x => x.Todos);
        }
    }
}
