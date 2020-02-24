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
        private readonly TodoContext _context;

        public TodoItemsController(IMediator mediator, TodoContext context) : base(mediator)
        {
            _context = context;
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
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody]CreateTodoItemCommand todoItem)
        {
            return Ok(await CommandAsync(todoItem));

            //var result = await _mediator.Send(todoItem);
            //return CreatedAtAction("GetTodoItem", new { id = result.Id }, result);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItem.Any(e => e.Id == id);
        }
    }
}
