// ReSharper disable CheckNamespace
using Microsoft.EntityFrameworkCore;
using Todo.Api.Persistence;
using Todo.Api.Persistence.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTodoDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
