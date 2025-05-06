using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        //DbSets to be mapped to Database table
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<CommentEntity> TaskComments { get; set; }


        // Data Seeding if tables are Empty
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //UserName Validation
            modelBuilder.Entity<UserEntity>()
               .HasIndex(u => u.UserName)
               .IsUnique();


            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, UserName = "Umang_Admin", HashedPassword = "Umang@123", Role = Role.Admin, CreatedDate = DateTime.UtcNow, LastUpdated = DateTime.UtcNow },
                new UserEntity { Id = 2, UserName = "Umang_User", HashedPassword = "Umang@123", Role = Role.User, CreatedDate = DateTime.UtcNow, LastUpdated = DateTime.UtcNow }
            );

            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity { 
                    Id = 1, 
                    Title = "Task 1", 
                    Description = "Sample Task assigned to Admin",
                    UserId = 1,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new TaskEntity
                {
                    Id = 2,
                    Title = "Task 2",
                    Description = "Sample Task assigned to User",
                    UserId = 2,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            );
        }
    }
}
