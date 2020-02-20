using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItem>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
