using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Domain.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(Guid id);
        Task AddAsync(TaskItem taskItem);
        Task UpdateAsync(TaskItem taskItem);
    }
}
