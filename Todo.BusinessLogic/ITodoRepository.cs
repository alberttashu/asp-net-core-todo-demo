using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Api.Persistence.Repositories
{
    public interface ITodoRepository
    {
        Task<Model.Todo> GetByIdAsync(int id);
        
        Task<List<Model.Todo>> GetAllAsync();

        Task<Model.Todo> CreateAsync(Model.Todo todo);
    }
}
