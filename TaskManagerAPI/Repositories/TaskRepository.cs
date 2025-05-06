using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Repositories
{
    public class TaskRepository(AppDbContext context) : ITaskRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<TaskEntity> AddTaskAsync(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskEntity?> GetTask(int Id)
        {
            var task = await _context.Tasks.FindAsync(Id);
            return task;
        }

        public async Task<List<TaskEntity>> GetTasksByUserId(int UserId)
        {
            return await _context.Tasks.Where(task => task.UserId == UserId).ToListAsync() ?? [];
        }
    }
}
