using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Core.Repositories;
using TestWebApi.Models;

namespace TestWebApi.Persistence.Repositories
{
    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        private readonly TodoContext _context;

        public TodoItemRepository(TodoContext context) : base(context)
        {
            _context = context;
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello Smile Direct Club");
        }

        public void CreateItem()
        {
            _context.Add(new TodoItem()
            {
                Id = 1,
                IsComplete = true,
                Name = "I'm a SDC Item"
            });
        }
    }
}
