using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Core;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, TodoItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTodoItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TodoItem> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = _mapper.Map<TodoItem>(request);
            _unitOfWork.Items.Update(todoItem);

            try
            {
                await _unitOfWork.CommitAsync();

                return todoItem;
            }
            catch (DbUpdateConcurrencyException dbex)
            {
                if (!TodoItemExists(todoItem.Id))
                {
                    throw new Exception("Not Found");
                }
                else
                {
                    throw dbex;
                }
            }
        }

        private bool TodoItemExists(long id)
        {
            return _unitOfWork.Items.FindAsync(m => m.Id == id).Result.Any();
        }
    }
}