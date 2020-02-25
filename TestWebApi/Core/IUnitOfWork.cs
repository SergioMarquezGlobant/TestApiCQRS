using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Core.Repositories;

namespace TestWebApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoItemRepository Items { get; }

        void Commit();
    }
}