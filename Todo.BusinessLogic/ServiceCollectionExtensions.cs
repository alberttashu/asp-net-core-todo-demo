// ReSharper disable CheckNamespace
using Todo.BusinessLogic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTodoLogic(this IServiceCollection services)
        {
            services.AddTransient<ITodoService, TodoService>();
            return services;
        }
    }
}
