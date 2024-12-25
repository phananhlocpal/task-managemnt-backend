using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Events
{
    public class TaskAssignedEvent
    {
        public Guid TaskId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime AssignedAt { get; private set; }

        public TaskAssignedEvent(Guid taskId, Guid userId, DateTime assignedAt)
        {
            TaskId = taskId;
            UserId = userId;
            AssignedAt = assignedAt;
        }
    }
}
