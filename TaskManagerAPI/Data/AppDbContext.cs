using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        //DbSets to be mapped to Database table
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskCommentsEntity> TaskComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //UserName Validation
            modelBuilder.Entity<UserEntity>()
               .HasIndex(u => u.UserName)
               .IsUnique();

            // Relationships
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskCommentsEntity>()
                .HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskCommentsEntity>()
                .HasOne(c => c.User)
                .WithMany(c => c.TaskComments) 
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // prevents multiple cascade path


            // Data Seeding if tables are Empty
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, UserName = "Admin", HashedPassword = "Zimozi@123", Role = Role.Admin },
                new UserEntity { Id = 2, UserName = "User", HashedPassword = "Zimozi@123", Role = Role.User }
            );

            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity { 
                    Id = 1, 
                    Title = "Task 1", 
                    Description = "Sample Task assigned to Admin",
                    UserId = 1,
                },
                new TaskEntity
                {
                    Id = 2,
                    Title = "Task 2",
                    Description = "Sample Task assigned to User",
                    UserId = 2,
                }
            );

            modelBuilder.Entity<TaskCommentsEntity>().HasData(
                    new TaskCommentsEntity
                    {
                        Id = 1,
                        Content = "This is Test Content 1",
                        UserId = 1,
                        TaskId = 1,
                    },
                    new TaskCommentsEntity
                    {
                        Id = 2,
                        Content = "This is Test Content 2",
                        UserId = 1,
                        TaskId = 1,
                        
                    }
                );
        }
    }
}
