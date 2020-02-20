using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.Querys;

namespace TestWebApi.Handlers.Querys
{
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly TodoContext _context;

        public GetAllTodoItemsHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItem.ToListAsync();
        }
    }
}
