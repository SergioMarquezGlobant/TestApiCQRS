using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.Querys;

namespace TestWebApi.Handlers.Querys
{
    public class GetTodoItemHandler : IRequestHandler<GetTodoItemQuery, TodoItem>
    {
        private readonly TodoContext _context;

        public GetTodoItemHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItem.FindAsync(request.Id);
        }
    }
}
