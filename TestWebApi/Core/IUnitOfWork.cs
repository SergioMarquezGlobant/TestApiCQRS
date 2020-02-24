using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Core.Repositories;

namespace TestWebApi.Core
{
    interface IUnitOfWork : IDisposable
    {
        ITodoItemRepository TodoItemRepository { get; }

        void Commit();
    }
}
