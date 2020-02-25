using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Commands;
using TestWebApi.Models;

namespace TestWebApi.Handlers.Commands
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public CreateTodoItemHandler(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var todoItem = _mapper.Map<TodoItem>(request);
                _context.TodoItem.Add(todoItem);
                await _context.SaveChangesAsync();

                return todoItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
