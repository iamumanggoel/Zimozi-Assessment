using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TaskManagerAPI.Entities
{
    [Table("Tasks")]
    public class TaskEntity : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public required string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int UserId { get; set; }

        public UserEntity? User { get; set; }

        public virtual ICollection<TaskCommentsEntity>? Comments { get; set; } = [];
    }

}
