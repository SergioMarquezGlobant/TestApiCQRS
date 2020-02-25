using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, TodoItem>
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public UpdateTodoItemHandler(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItem> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = _mapper.Map<TodoItem>(request);
            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbex)
            {
                //TODO fix this...
                if (!TodoItemExists(todoItem.Id))
                {
                    throw new Exception("Not Found");
                }
                else
                {
                    throw dbex;
                }
            }
                
            return todoItem;
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItem.Any(e => e.Id == id);
        }
    }
}
