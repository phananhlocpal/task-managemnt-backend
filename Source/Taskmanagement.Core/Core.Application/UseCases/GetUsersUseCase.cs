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
    public class GetUsersUseCase : IRequestHandler<GetUsersQuery, IEnumerable<UserReadDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUsersUseCase(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserReadDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userDtos = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDto>>(userDtos);
        }
    }
}
