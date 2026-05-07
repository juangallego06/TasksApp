namespace Tasks.Application.DTO.TaskItem
{
    public sealed record CreateTaskItemDto(
        string Title,
        string? Description,
        int UserId,
        string? MetadataJson
    );
}