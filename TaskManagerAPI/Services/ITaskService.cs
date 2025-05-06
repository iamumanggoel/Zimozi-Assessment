using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;

namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        Task<TaskEntity> CreateTaskAsync(TaskCreateRequest requestDto);
        Task<TaskEntity?> GetTask(int Id);
        Task<List<TaskEntity>> GetTasksByUserId(int userId);
    }
}