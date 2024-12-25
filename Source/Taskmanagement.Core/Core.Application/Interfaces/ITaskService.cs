using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.DTOs.TaskItemDtos;

namespace Core.Application.Interfaces
{
    public interface ITaskService
    {
        Task<Guid> CreateTaskAsync(TaskItemCreateDto dto);
        Task AssignTaskToUserAsync(Guid taskId, Guid userId);
    }
}
