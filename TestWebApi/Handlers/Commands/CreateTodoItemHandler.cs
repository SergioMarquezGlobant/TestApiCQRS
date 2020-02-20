using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private readonly TodoContext _context;

        public CreateTodoItemHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            //convert
            var todoItem = new TodoItem
            {
                Id = request.Id,
                IsComplete = request.IsComplete,
                Name = request.Name
            };

            _context.TodoItem.Add(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
    }
}
