using MediatR;
using TestWebApi.Models;

namespace TestWebApi.Commands
{
    public class DeleteTodoItemCommand : IRequest<TodoItem>
    {
        public long Id { get; set; }
    }
}
