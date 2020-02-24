using System;
using System.Collections.Generic;
using System.Linq;
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
            Items = new TodoItemRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public ITodoItemRepository TodoItemRepository { get; }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
