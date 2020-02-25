using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Core;
using TestWebApi.Core.Repositories;
using TestWebApi.Models;
using TestWebApi.Querys;

namespace TestWebApi.Handlers.Querys
{
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTodoItemsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Items.GetAllAsync();
        }
    }
}
