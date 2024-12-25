using Core.Application.Commands;
using Core.Application.Queries.UserQueries;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var userId = await _mediator.Send(user);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, user);
        }
    }
}
