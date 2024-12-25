using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Commands;
using Core.Application.DTOs;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.UseCases
{
    public class CreateTaskUseCase : IRequestHandler<CreateTaskItemCommand, Guid>
    {
        private readonly ITaskItemRepository _taskRepository;

        public CreateTaskUseCase(ITaskItemRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Guid> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem(Guid.NewGuid(), request.Title, request.Description, request.DueDate, request.AssignedUserId);
            await _taskRepository.AddAsync(task);
            return task.Id;
        }
    }
}
