using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Api.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<Model.Todo> GetByIdAsync(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Model.Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Model.Todo> CreateAsync(Model.Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}
