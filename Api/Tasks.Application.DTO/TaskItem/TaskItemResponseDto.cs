using Tasks.Domain.Entity.Enums;

namespace Tasks.Application.DTO.TaskItem
{
    public class TaskItemResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public TaskItemStatus Status { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public string? MetadataJson { get; set; }
    }
}