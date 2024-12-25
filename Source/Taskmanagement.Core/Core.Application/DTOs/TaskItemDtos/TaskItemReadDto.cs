using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.TaskItemDtos
{
    public class TaskItemReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedUserId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
