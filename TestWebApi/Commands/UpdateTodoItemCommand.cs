using MediatR;
using TestWebApi.Dto;
using TestWebApi.Models;

namespace TestWebApi.Commands
{
    public class UpdateTodoItemCommand : TodoItemDto, IRequest<TodoItem>
    {

    }
}
