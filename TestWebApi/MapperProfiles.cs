using AutoMapper;
using TestWebApi.Dto;
using TestWebApi.Models;

namespace TestWebApi
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
        }
    }
}
