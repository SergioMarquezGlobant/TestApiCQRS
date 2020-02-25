using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Core;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTodoItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var todoItem = _mapper.Map<TodoItem>(request);
                _unitOfWork.Items.AddAsync(todoItem);
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
