using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Entities
{
    [Table("TaskComments")]
    public class CommentEntity: BaseEntity
    {
        [StringLength(500)]
        public string? Content { get; set; }
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual required TaskEntity Task { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual required UserEntity User { get; set; }

        

    }
}
