using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Models;
using TestWebApi.Querys;

namespace TestWebApi.Controllers
{
    public class TodoItemsController : ApiControllerBase
    {
        public TodoItemsController(IMediator mediator) : base(mediator)
        {
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IActionResult> GetTodoItem()
        {
            return Ok(await QueryAsync(new GetAllTodoItemsQuery()));
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(long id)
        {
            return Ok(await QueryAsync(new GetTodoItemQuery(id)));
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, [FromBody]UpdateTodoItemCommand todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            return Ok(await CommandAsync(todoItem));
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody] CreateTodoItemCommand todoItem)
        {
            return Ok(await CommandAsync(todoItem));
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem([FromBody]DeleteTodoItemCommand todoItem)
        {
            return Ok(await CommandAsync(todoItem));
        }
    }
}