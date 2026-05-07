using Tasks.Application.DTO.TaskItem;
using Tasks.Domain.Entity.Enums;
using Tasks.Shared.Common;

namespace Tasks.Application.Interfaces.UseCases
{
    public interface ITaskItemUseCase
    {
        Task<Response<IEnumerable<TaskItemResponseDto>>> GetAllTaskItemsAsync(TaskItemStatus? status = null);

        Task<Response<TaskItemResponseDto>> GetTaskItemByIdAsync(int id);

        Task<Response<bool>> CreateTaskItemAsync(CreateTaskItemDto createTaskItemDto);

        Task<Response<TaskItemResponseDto>> UpdateTaskStatusAsync(int id, UpdateTaskStatusDto updateTaskStatusDto);
    }
}
