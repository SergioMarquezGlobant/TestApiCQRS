using System.Threading.Tasks;
using TestWebApi.Core;
using TestWebApi.Core.Repositories;
using TestWebApi.Models;
using TestWebApi.Persistence.Repositories;

namespace TestWebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        public ITodoItemRepository Items { get; }


        public UnitOfWork(TodoContext context)
        {
            _context = context;

            Items = new TodoItemRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync() 
        {
            return await _context.SaveChangesAsync();
        }
    }
}