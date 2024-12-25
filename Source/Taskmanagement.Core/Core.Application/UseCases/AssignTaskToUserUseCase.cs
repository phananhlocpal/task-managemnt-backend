using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Commands;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.UseCases
{
    public class AssignTaskToUserUseCase : IRequestHandler<AssignTaskCommand, Unit>
    {
        private readonly ITaskItemRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public AssignTaskToUserUseCase(ITaskItemRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AssignTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.TaskId);
            if (task == null)
                throw new ArgumentException("Task not found", nameof(request.TaskId));

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new ArgumentException("User not found", nameof(request.UserId));

            // Assign task to user
            task.AssignToUser(request.UserId);
            await _taskRepository.UpdateAsync(task);
            return Unit.Value;
        }
    }
}
