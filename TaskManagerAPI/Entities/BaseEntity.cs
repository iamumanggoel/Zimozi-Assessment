using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        //Add Audit & other common properties
    }
}
