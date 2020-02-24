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
        public TodoItemRepository(DbContext context) : base(context)
        {
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello Smile Direct Club");
        }

        public void CreateItem()
        {
            Context.Add(new TodoItem()
            {
                Id = 1,
                IsComplete = true,
                Name = "I'm a SDC Item"
            });
        }
    }
}
