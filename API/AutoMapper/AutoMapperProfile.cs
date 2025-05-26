using System;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TodoItem, TodoListDto>();
        CreateMap<TodoCreateDto, TodoItem>();
        CreateMap<TodoListDto, TodoItem>();

    }
}
