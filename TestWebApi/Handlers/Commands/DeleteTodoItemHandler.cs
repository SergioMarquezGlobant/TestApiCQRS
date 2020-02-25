using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, TodoItem>
    {
        private readonly TodoContext _context;

        public DeleteTodoItemHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {

            var todoItem = await _context.TodoItem.FindAsync(request.Id);
            if (todoItem == null)
            {
                throw new Exception("Not found");
            }

            try
            {
                _context.TodoItem.Remove(todoItem);
                await _context.SaveChangesAsync();

                return todoItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
