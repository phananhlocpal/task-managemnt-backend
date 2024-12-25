using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.DTOs.UserDtos;
using Core.Application.Queries.UserQueries;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.UseCases
{
    public class GetUserByIdUseCase : IRequestHandler<GetUserByIdQuery, UserReadDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserReadDto>(user);
        }
    }
}
