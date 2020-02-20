using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Querys
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {

    }
}
