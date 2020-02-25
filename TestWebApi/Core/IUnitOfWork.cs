using System;
using System.Threading.Tasks;
using TestWebApi.Core.Repositories;

namespace TestWebApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoItemRepository Items { get; }

        void Commit();

        Task<int> CommitAsync();
    }
}