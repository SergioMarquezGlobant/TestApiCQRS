using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Core;
using TestWebApi.Core.Repositories;
using TestWebApi.Models;
using TestWebApi.Querys;

namespace TestWebApi.Handlers.Querys
{
    public class GetTodoItemHandler : IRequestHandler<GetTodoItemQuery, TodoItem>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTodoItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoItem> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            //return await _context.TodoItem.FindAsync(request.Id);
            return await _unitOfWork.Items.GetAsync(request.Id);
        }
    }
}