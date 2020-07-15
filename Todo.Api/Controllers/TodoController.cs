using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Api.Contracts;
using Todo.Api.Persistence.Repositories;
using Todo.Api.Extensions;
using Todo.Api.Model;
using DayOfWeek = Todo.Api.Model.DayOfWeek;

namespace Todo.Api.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _todoRepository;

        public TodoController(ILogger<TodoController> logger,
            ITodoRepository todoRepository)
        {
            _logger = logger;
            _todoRepository = todoRepository;
        }


        /// <summary>
        /// Позволяет получить конкретную задачу.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetTask")]
        [Produces("application/json",
            "application/vnd.todo.task+json",
            "application/vnd.todo.taskwithoutdescription+json")]
        public async Task<ActionResult<TodoOutputContract>> GetTask(int id, [FromHeader(Name = "Accept")] string mediaType)
        {
            var todoEntity = await _todoRepository.GetByIdAsync(id);

            if (todoEntity == null)
            {
                return NotFound();
            }

            var representation = GetMediaTypeName(MediaTypeHeaderValue.Parse(mediaType));

            if(representation == "taskwithoutdescription")
            {
                var resource = todoEntity.ToTodoWithoutDescriptionOutputContract();
                return Ok(resource);
            }
            else
            {
                var resource = todoEntity.ToTodoOutputContract();
                return Ok(resource);
            }
        }

        [HttpGet]
        [Route("", Name = "GetTasks")]
        public ActionResult<List<TodoOutputContract>> GetTasks()
        {
            var resource = new List<TodoOutputContract>()
            {
                new TodoOutputContract()
                {
                    Id = 10,
                    Description = "Task description",
                    Title = "First Task"
                }
            };

            return Ok(resource);
        }


        [HttpPost]
        public async Task<ActionResult> CreateTodo(CreateTaskInputContract request)
        {
            var todo = new Model.Todo(request.Title, request.Description, new Interval(DayOfWeek.Monday, 1));

            todo = await _todoRepository.CreateAsync(todo);

            var createdTask = todo.ToTodoOutputContract();

            return CreatedAtRoute("GetTask", new {id = createdTask.Id}, createdTask);
        }


        private string GetMediaTypeName(MediaTypeHeaderValue mediaType)
        {
            var mediaTypeNameFacets = mediaType
                .Facets
                .Except(new[]
                {
                    new StringSegment("vnd"),
                    new StringSegment("todo")
                });

            var mediaTypeName = String.Join(".", mediaTypeNameFacets);
            return mediaTypeName;
        }

    }
}