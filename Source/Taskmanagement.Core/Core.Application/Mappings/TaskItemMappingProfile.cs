using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.DTOs.TaskItemDtos;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
    public class TaskItemMappingProfile : Profile
    {
        public TaskItemMappingProfile()
        {
            CreateMap<TaskItem, TaskItemReadDto>();
            CreateMap<TaskItemCreateDto, TaskItem>();
        }
    }
}
