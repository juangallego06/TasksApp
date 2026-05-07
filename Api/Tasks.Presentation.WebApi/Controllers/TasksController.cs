using Microsoft.AspNetCore.Mvc;
using Tasks.Application.DTO.TaskItem;
using Tasks.Application.Interfaces.UseCases;
using Tasks.Domain.Entity.Enums;

namespace Tasks.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskItemUseCase _taskItemUseCase;

        public TasksController(ITaskItemUseCase taskItemUseCase)
        {
            _taskItemUseCase = taskItemUseCase;
        }

        [HttpGet("{status?}")]
        public async Task<IActionResult> GetAllTaskItems([FromRoute] TaskItemStatus? status = null)
        {
            var response = await _taskItemUseCase.GetAllTaskItemsAsync(status);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetTaskItemById([FromRoute] int id)
        {
            var response = await _taskItemUseCase.GetTaskItemByIdAsync(id);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskItem([FromBody] CreateTaskItemDto createTaskItemDto)
        {
            var response = await _taskItemUseCase.CreateTaskItemAsync(createTaskItemDto);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateTaskStatus([FromRoute] int id, [FromBody] UpdateTaskStatusDto updateTaskStatusDto)
        {
            var response = await _taskItemUseCase.UpdateTaskStatusAsync(id, updateTaskStatusDto);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }
    }
}
