using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Commands;
using Core.Domain.Interfaces;
using MediatR;
using Core.Domain.Entities;
using Core.Domain.Enumerations;

namespace Core.Application.UseCases
{
    public class CreateUserUseCase : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(Guid.NewGuid(), request.Name, request.Email, UserRoleEnum.Default); 
            return Task.FromResult(user.Id);
        }
    }
}
