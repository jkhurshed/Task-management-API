using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace TaskManagerApi.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        CreateMap<CreateTaskDto, TaskItem>();
        CreateMap<UpdateTaskDto, TaskItem>();
    }
}