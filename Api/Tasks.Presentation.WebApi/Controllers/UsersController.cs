using Microsoft.AspNetCore.Mvc;
using Tasks.Application.DTO.User;
using Tasks.Application.Interfaces.UseCases;

namespace Tasks.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;

        public UsersController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            var response = await _userUseCase.CreateUserAsync(request);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userUseCase.GetAllUsersAsync();

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await _userUseCase.GetUserByIdAsync(id);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }
    }
}
