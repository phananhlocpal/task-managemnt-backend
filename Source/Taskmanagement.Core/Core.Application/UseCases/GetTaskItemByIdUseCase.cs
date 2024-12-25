using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.DTOs.TaskItemDtos;
using Core.Application.Queries.TaskItemQueries;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.UseCases
{
    public class GetTaskItemByIdUseCase : IRequestHandler<GetTaskItemByIdQuery, TaskItemReadDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public GetTaskItemByIdUseCase(IMapper mapper, ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItemReadDto> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
        {
            TaskItem taskItem = await _taskItemRepository.GetByIdAsync(request.Id);
            if (taskItem == null)
                throw new ArgumentException("Task not found", nameof(request.Id));

            var taskItemDto = _mapper.Map<TaskItemReadDto>(taskItem);
            return taskItemDto;
        }
    }
}
