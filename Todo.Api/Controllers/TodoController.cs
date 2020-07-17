using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Contracts;
using Todo.Api.Persistence.Repositories;
using Todo.Api.Extensions;
using Todo.Api.Model;
using Todo.Api.Persistence;
using Todo.BusinessLogic;
using DayOfWeek = Todo.Api.Model.DayOfWeek;

namespace Todo.Api.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _todoService;

        public TodoController(
            ILogger<TodoController> logger,
            ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
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
            var todoEntity = await _todoService.GetTodo(id);

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
        public async Task<ActionResult<List<TodoOutputContract>>> GetTasks()
        {
            var tasks = await _todoService.GetAllTodos();

            var outputModel = tasks.Select(x => x.ToTodoOutputContract());

            return Ok(outputModel);
        }


        [HttpPost]
        public async Task<ActionResult> CreateTodo(CreateTaskInputContract request)
        {
            var todo = await _todoService.CreateOneTimeTodo(request.Title, request.Description);

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