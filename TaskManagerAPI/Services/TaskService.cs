using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Services
{
    public class TaskService(ITaskRepository repository) : ITaskService
    {
        private readonly ITaskRepository _repository = repository;

        public async Task<TaskResponse> CreateTaskAsync(TaskCreateRequest requestDto)
        {
            var task = new TaskEntity
            {
                Title = requestDto.Title,
                Description = requestDto.Description,
                UserId = requestDto.UserId,
            };

            var saved = await _repository.AddTaskAsync(task);

            return new TaskResponse
            {
                Id = saved.Id,
                Title = saved.Title,
                Description = saved.Description,
                UserId = saved.UserId,
                Comments = []
            };
        }


        public async Task<TaskResponse?> GetTask(int Id)
        {
            TaskEntity? task = await _repository.GetTask(Id);

            if (task is null) 
                return null;

            var taskDto = new TaskResponse
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
                UserId = task.UserId,
                Comments = task.Comments?.Select(c => new CommentsResponse
                {
                    Content = c.Content,
                }).ToList() 
            };

            return taskDto;
        }

        public async Task<List<TaskResponse>> GetTasksByUserId(int userId)
        {
            var tasks = await _repository.GetTasksByUserId(userId);

            var taskDtos = tasks.Select(task => new TaskResponse
                            {
                                Id = task.Id,
                                Title = task.Title,
                                Description = task.Description,
                                UserId = task.UserId,
                                Comments = task.Comments?.Select(c => new CommentsResponse
                                {
                                    Content = c.Content
                                }).ToList()
                            })
                        .ToList(); 

            return taskDtos;
        }

    }
}
