using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Model;
using Todo.Api.Persistence.Repositories;

namespace Todo.BusinessLogic
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public Task<Api.Model.Todo> GetTodo(int id)
        {
            return _todoRepository.GetByIdAsync(id);
        }

        public Task<Api.Model.Todo> CreateOneTimeTodo(string summary, string description)
        {
            var todo = new Api.Model.Todo(summary, description, null);
            return _todoRepository.CreateAsync(todo);
        }

        public Task<Api.Model.Todo> CreateTodo(string summary, string description, Interval interval)
        {
            var todo = new Api.Model.Todo(summary, description, interval);
            return _todoRepository.CreateAsync(todo);
        }

        public Task<List<Api.Model.Todo>> GetAllTodos()
        {
            return _todoRepository.GetAllAsync();
        }
    }
}
