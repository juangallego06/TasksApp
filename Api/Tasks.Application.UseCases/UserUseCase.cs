using AutoMapper;
using Tasks.Application.DTO.User;
using Tasks.Application.Interfaces.Persistence;
using Tasks.Application.Interfaces.UseCases;
using Tasks.Application.Validators;
using Tasks.Domain.Entity;
using Tasks.Shared.Common;

namespace Tasks.Application.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateUserDtoValidator _createUserDtoValidator;

        public UserUseCase(IUnitOfWork unitOfWork, IMapper mapper, CreateUserDtoValidator createUserDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createUserDtoValidator = createUserDtoValidator;
        }

        public async Task<Response<UserResponseDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var response = new Response<UserResponseDto>();
            var validationResult = await _createUserDtoValidator.ValidateAsync(createUserDto);

            if(!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Validation failed.";
                response.Errors = validationResult.Errors;
                return response;
            }


            var user = await _unitOfWork.Users.AddAsync(_mapper.Map<User>(createUserDto));

            response.IsSuccess = true;
            response.Data = _mapper.Map<UserResponseDto>(user);
            response.Message = "User created successfully.";
            

            return response;
        }

        public async Task<Response<IEnumerable<UserResponseDto>>> GetAllUsersAsync()
        {
           var response = new Response<IEnumerable<UserResponseDto>>();
           var users = await _unitOfWork.Users.GetAllAsync();
           response.IsSuccess = true;
           response.Data = _mapper.Map<IEnumerable<UserResponseDto>>(users);
           response.Message = "Users retrieved successfully.";
           return response;
        }

        public async Task<Response<UserResponseDto>> GetUserByIdAsync(int id)
        {
            var response = new Response<UserResponseDto>();
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = "User not found.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = _mapper.Map<UserResponseDto>(user);
            response.Message = "User retrieved successfully.";
            return response;
        }
    }
}
