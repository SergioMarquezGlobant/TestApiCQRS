using MediatR;
using TestWebApi.Models;

namespace TestWebApi.Querys
{
    public class GetTodoItemQuery : IRequest<TodoItem>
    {
        public long Id { get; }

        public GetTodoItemQuery(long id)
        {
            Id = id;
        }
    }
}
