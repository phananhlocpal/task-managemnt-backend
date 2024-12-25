using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.DTOs.UserDtos;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
