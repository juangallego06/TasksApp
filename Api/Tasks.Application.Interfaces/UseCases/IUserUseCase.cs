using Tasks.Application.DTO.User;
using Tasks.Shared.Common;

namespace Tasks.Application.Interfaces.UseCases
{
    public interface IUserUseCase
    {
        Task<Response<IEnumerable<UserResponseDto>>> GetAllUsersAsync();

        Task<Response<UserResponseDto>> GetUserByIdAsync(int id);

        Task<Response<UserResponseDto>> CreateUserAsync(CreateUserDto createUserDto);
    }
}
