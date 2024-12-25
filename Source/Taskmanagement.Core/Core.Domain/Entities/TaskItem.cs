using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Events;

namespace Core.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public Guid AssignedUserId { get; private set; }
        public bool IsCompleted { get; private set; }

        public TaskItem(Guid id, string title, string description, DateTime dueDate, Guid assignedUserId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty", nameof(title));

            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            AssignedUserId = assignedUserId;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void AssignToUser(Guid userId)
        {
            AssignedUserId = userId;
            var taskAssignedEvent = new TaskAssignedEvent(Id, userId, DateTime.UtcNow);
        }
    }
}
