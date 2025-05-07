using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Data
{
    public static class InMemDb_Seeding
    {
        public static void Seed(AppDbContext db)
        {
            db.Database.EnsureCreated();

            if (!db.Users.Any())
            {
                var admin = new UserEntity { Id = 1, UserName = "Admin", HashedPassword = "Zimozi@123", Role = Role.Admin };
                var user = new UserEntity { Id = 2, UserName = "User", HashedPassword = "Zimozi@123", Role = Role.User };

                db.Users.AddRange(admin, user);

                db.Tasks.AddRange(
                    new TaskEntity { Id = 1, Title = "Task 1", Description = "Sample Task assigned to Admin", UserId = 1 },
                    new TaskEntity { Id = 2, Title = "Task 2", Description = "Sample Task assigned to User", UserId = 2 }
                );

                db.TaskComments.AddRange(
                    new TaskCommentsEntity { Id = 1, Content = "This is Test Content 1", UserId = 1, TaskId = 1 },
                    new TaskCommentsEntity { Id = 2, Content = "This is Test Content 2", UserId = 1, TaskId = 1 }
                );

                db.SaveChanges();
            }
        }
    }
}
