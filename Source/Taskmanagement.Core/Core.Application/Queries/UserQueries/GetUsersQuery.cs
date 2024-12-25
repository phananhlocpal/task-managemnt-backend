using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.DTOs.UserDtos;
using MediatR;

namespace Core.Application.Queries.UserQueries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserReadDto>>
    {
        public GetUsersQuery()
        {

        }
    }
}
