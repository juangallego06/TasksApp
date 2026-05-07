namespace Tasks.Application.DTO.User
{
    public sealed record CreateUserDto(
        string UserName,
        string Email
    );
}
