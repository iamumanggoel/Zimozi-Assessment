using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Entities
{
    [Table("Users")]
    public class UserEntity: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public required string UserName { get; set; }

        [Required]
        [StringLength(40)]
        public required string HashedPassword { get; set; }

        [Required]
        public required Role Role { get; set; } = Role.User;

    }

    public enum Role
    {
        Admin,
        User
    }
}
