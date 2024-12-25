using Core.Application.Commands;
using Core.Application.Queries.TaskItemQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _mediator.Send(new GetTaskItemsQuery());
           
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _mediator.Send(new GetTaskItemByIdQuery(id));
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskItemCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var taskId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTaskById), new { id = taskId }, taskId);
        }

        [HttpPost("{taskId}/assign")]
        public async Task<IActionResult> AssignTaskToUser(Guid taskId, [FromBody] AssignTaskCommand command)
        {
            if (command == null || taskId != command.TaskId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        
    }
}
