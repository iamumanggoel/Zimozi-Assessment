using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Entities
{
    [Table("TaskComments")]
    public class TaskCommentsEntity : BaseEntity
    {
        [StringLength(500)]
        public string? Content { get; set; }

        [Required]
        public int TaskId { get; set; }

        public TaskEntity? Task { get; set; }

        [Required]
        public int UserId { get; set; }

        public UserEntity? User { get; set; }
    }

}
