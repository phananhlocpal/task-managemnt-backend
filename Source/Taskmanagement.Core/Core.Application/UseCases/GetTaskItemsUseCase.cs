using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.DTOs.TaskItemDtos;
using Core.Application.Queries.TaskItemQueries;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.UseCases
{
    public class GetTaskItemsUseCase : IRequestHandler<GetTaskItemsQuery, IEnumerable<TaskItemReadDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTaskItemsUseCase(IMapper mapper, ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }
    

        public async Task<IEnumerable<TaskItemReadDto>> Handle(GetTaskItemsQuery request, CancellationToken cancellationToken)
        {
            var taskItemDtos = await _taskItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskItemReadDto>>(taskItemDtos);
        }
    }
}
