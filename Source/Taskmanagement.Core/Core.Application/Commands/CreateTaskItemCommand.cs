using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Core.Application.Commands
{
    public class CreateTaskItemCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedUserId { get; set; }
    }

}
