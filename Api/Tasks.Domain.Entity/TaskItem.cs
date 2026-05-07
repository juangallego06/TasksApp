using Tasks.Domain.Entity.Enums;

namespace Tasks.Domain.Entity
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required TaskItemStatus Status { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get;}
        public string? MetadataJson { get; set; }
        public User User { get; set; } = default!;
    }
}
