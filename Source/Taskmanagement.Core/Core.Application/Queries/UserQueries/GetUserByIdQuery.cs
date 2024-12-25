using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.DTOs.UserDtos;
using MediatR;

namespace Core.Application.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<UserReadDto>
    {
        public Guid Id { get; set; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
