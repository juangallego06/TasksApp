using AutoMapper;
using Tasks.Application.DTO.TaskItem;
using Tasks.Application.Interfaces.Persistence;
using Tasks.Application.Interfaces.UseCases;
using Tasks.Application.Validators;
using Tasks.Domain.Entity;
using Tasks.Domain.Entity.Enums;
using Tasks.Shared.Common;

namespace Tasks.Application.UseCases
{
    public class TaskItemUseCase: ITaskItemUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateTaskItemDtoValidator _createTaskItemDtoValidator;

        public TaskItemUseCase(IUnitOfWork unitOfWork, IMapper mapper, CreateTaskItemDtoValidator createTaskItemDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createTaskItemDtoValidator = createTaskItemDtoValidator;
        }

        public async Task<Response<bool>> CreateTaskItemAsync(CreateTaskItemDto createTaskItemDto)
        {
            var response = new Response<bool>();
            var validationResult = await _createTaskItemDtoValidator.ValidateAsync(createTaskItemDto);

            if(!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Validation failed.";
                response.Errors = validationResult.Errors;
                return response;
            }

            var userExisting = await _unitOfWork.Users.GetByIdAsync(createTaskItemDto.UserId);

            if(userExisting is null)
            {
                response.IsSuccess = false;
                response.Message = "User not found.";
                return response;
            }

            var taskItemEntity = _mapper.Map<TaskItem>(createTaskItemDto);

            taskItemEntity.Status = TaskItemStatus.Pending;

            var createdTaskItem = await _unitOfWork.TaskItems.AddAsync(taskItemEntity);

            response.IsSuccess = true;
            response.Message = "Task item created successfully.";

            return response;
        }

        public async Task<Response<IEnumerable<TaskItemResponseDto>>> GetAllTaskItemsAsync(TaskItemStatus? status = null)
        {
            var response = new Response<IEnumerable<TaskItemResponseDto>>();
            var taskItems = await _unitOfWork.TaskItems.GetAllAsync(status);
            response.IsSuccess = true;
            response.Data = _mapper.Map<IEnumerable<TaskItemResponseDto>>(taskItems);
            response.Message = "Task items retrieved successfully.";
            return response;
        }

        public async Task<Response<TaskItemResponseDto>> GetTaskItemByIdAsync(int id)
        {
            var response = new Response<TaskItemResponseDto>();
            var taskItem = await _unitOfWork.TaskItems.GetByIdAsync(id);
            if (taskItem == null)
            {
                response.IsSuccess = false;
                response.Message = "Task not found.";
                return response;
            }
            response.IsSuccess = true;
            response.Data = _mapper.Map<TaskItemResponseDto>(taskItem);
            response.Message = "Task item retrieved successfully.";
            return response;
        }

        public async Task<Response<TaskItemResponseDto>> UpdateTaskStatusAsync(int id, UpdateTaskStatusDto updateTaskStatusDto)
        {
            var response = new Response<TaskItemResponseDto>();
            
            var taskItemExisting = await _unitOfWork.TaskItems.GetByIdAsync(id);

            if(taskItemExisting is null)
            {
                response.IsSuccess = false;
                response.Message = "Task item not found.";
                return response;
            }

            if(taskItemExisting.Status == TaskItemStatus.Pending && updateTaskStatusDto.Status == TaskItemStatus.Done)
            {
                response.IsSuccess = false;
                response.Message = "Task cannot move directly from Pending to Done.";
                return response;
            }

            taskItemExisting.Status = updateTaskStatusDto.Status;

            var updatedTaskItem = await _unitOfWork.TaskItems.UpdateAsync(taskItemExisting);

            response.IsSuccess = true;
            response.Message = "Task item status updated successfully.";
            response.Data = _mapper.Map<TaskItemResponseDto>(updatedTaskItem);

            return response;
        }
    }
}
