using AutoMapper;
using TodoApi.Models;
using TodoApi.Dtos;

namespace TodoApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoCreateDto, TodoItem>();
            CreateMap<TodoUpdateDto, TodoItem>();
            CreateMap<TodoItem, TodoCreateDto>();
        }
    }
}
