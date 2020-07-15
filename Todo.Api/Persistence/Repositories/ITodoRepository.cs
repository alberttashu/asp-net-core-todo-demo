using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Api.Persistence.Repositories
{
    public interface ITodoRepository
    {
        public Task<Model.Todo> GetByIdAsync(int id);
        
        public Task<List<Model.Todo>> GetAllAsync();

        public Task<Model.Todo> CreateAsync(Model.Todo todo);
    }
}
