using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Core.Application.Commands
{
    public class AssignTaskCommand : IRequest<Unit>
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }

        public AssignTaskCommand(Guid taskId, Guid userId)
        {
            TaskId = taskId;
            UserId = userId;
        }
    }
}
