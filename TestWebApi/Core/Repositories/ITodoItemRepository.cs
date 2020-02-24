using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Core.Repositories
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        void DoSomething();

        void CreateItem();
    }
}
