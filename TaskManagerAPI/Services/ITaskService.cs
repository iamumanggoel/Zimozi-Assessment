using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;

namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        Task<TaskResponse> CreateTaskAsync(TaskCreateRequest requestDto);
        Task<TaskResponse?> GetTask(int Id);
        Task<List<TaskResponse>> GetTasksByUserId(int userId);
    }
}