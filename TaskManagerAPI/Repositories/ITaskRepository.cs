using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskEntity> AddTaskAsync(TaskEntity task);
        Task<TaskEntity?> GetTask(int Id);
        Task<List<TaskEntity>> GetTasksByUserId(int UserId);
    }
}