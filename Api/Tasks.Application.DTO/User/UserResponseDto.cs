namespace Tasks.Application.DTO.User
{
    public sealed record UserResponseDto(
        int Id,
        string UserName,
        string Email,
        DateTime CreatedAt
    );
}
