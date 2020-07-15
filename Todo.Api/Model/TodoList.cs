using System.Collections.Generic;

namespace Todo.Api.Model
{
    public class TodoList : Entity
    {
        public string Name { get; set; }

        public List<Todo> Todos { get; set; }

    }
}
