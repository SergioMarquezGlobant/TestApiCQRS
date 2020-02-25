using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Core;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, TodoItem>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoItem> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _unitOfWork.Items.GetAsync(request.Id);
            if (todoItem == null)
            {
                throw new Exception("Not found");
            }

            try
            {
                _unitOfWork.Items.Remove(todoItem);
                await _unitOfWork.CommitAsync();

                return todoItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}