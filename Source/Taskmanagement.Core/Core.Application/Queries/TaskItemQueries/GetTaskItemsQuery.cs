using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.DTOs.TaskItemDtos;
using MediatR;

namespace Core.Application.Queries.TaskItemQueries
{
    public class GetTaskItemsQuery : IRequest<IEnumerable<TaskItemReadDto>>
    {
        public GetTaskItemsQuery()
        {

        }
    }
}
