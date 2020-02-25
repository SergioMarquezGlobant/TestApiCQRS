using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            //var query = new GetAllTodoItemsQuery();
            //var result = await _mediator.Send(query);
            //return Ok(result);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(long id)
        {
            return Ok(await QueryAsync(new GetTodoItemQuery(id)));

            //var query = new GetTodoItemQuery(id);
            //var result = await _mediator.Send(query);
            //return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody] CreateTodoItemCommand todoItem)
        {
            return Ok(await CommandAsync(todoItem));

            //var result = await _mediator.Send(todoItem);
            //return CreatedAtAction("GetTodoItem", new { id = result.Id }, result);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            throw new NotImplementedException();
        }

        private bool TodoItemExists(long id)
        {
            throw new NotImplementedException();
        }
    }
}