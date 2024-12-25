using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Core.Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
