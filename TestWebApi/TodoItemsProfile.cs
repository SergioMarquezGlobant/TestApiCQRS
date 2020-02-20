using AutoMapper;
using TestWebApi.DTO;
using TestWebApi.Models;

namespace TestWebApi
{
    public class TodoItemsProfile : Profile
    {
        public TodoItemsProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>();
        }
    }
}
