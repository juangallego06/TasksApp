using Tasks.Domain.Entity.Enums;

namespace Tasks.Application.DTO.TaskItem
{
    public sealed record UpdateTaskStatusDto(
        TaskItemStatus Status
    );
}