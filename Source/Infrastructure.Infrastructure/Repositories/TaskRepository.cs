using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Infrastructure.Repositories
{
    public class TaskRepository : ITaskItemRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _context.Tasks.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(Guid id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            _context.Tasks.Update(taskItem);
            await _context.SaveChangesAsync();
        }
    }
}
