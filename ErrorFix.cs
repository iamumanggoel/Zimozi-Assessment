/// <summary>
/// 1. Return Type
///     GetTask previously returned Task<Task> without using await.
///     GetAllTasks returned List<Task> but was calling an async iquerable method
/// 2. Proper async/await Use
///     Added async and await to both methods to correctly
/// 3. Path with Namespace name added for Task because Task is also a Thread Library in C#. It could cause conflict
/// 4. Added try-catch error handlying
/// </summary>
public class TaskService
{
    private readonly DbContext _dbContext;

    public TaskService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskManagerAPI.Entities.Task?> GetTaskAsync(int id)
    {
        try
        {
            return await _dbContext.Set<TaskManagerAPI.Entities.Task>().FirstOrDefaultAsync(t => t.Id == id);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving the task.", ex);
        }
    }

    public async Task<List<Task>> GetAllTasksAsync()
    {
        try
        {
            return await _dbContext.Set<Task>().ToListAsync();
        }
        catch (Exception ex)
        {
            // Optional: Log exception here
            throw new ApplicationException("An error occurred while retrieving all tasks.", ex);
        }
    }
}