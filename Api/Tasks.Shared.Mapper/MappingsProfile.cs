using AutoMapper;
using Tasks.Application.DTO.TaskItem;
using Tasks.Application.DTO.User;
using Tasks.Domain.Entity;

namespace Tasks.Shared.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateTaskItemDto, TaskItem>();
            CreateMap<TaskItem, TaskItemResponseDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
