using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Model;

namespace Todo.BusinessLogic
{
    public interface ITodoService
    {
        Task<Api.Model.Todo> GetTodo(int id);
        Task<Api.Model.Todo> CreateOneTimeTodo(string summary, string description);
        Task<Api.Model.Todo> CreateTodo(string summary, string description, Interval interval);
        Task<List<Api.Model.Todo>> GetAllTodos();
    }
}