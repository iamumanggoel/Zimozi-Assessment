using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models.DTOs
{
    public class TaskCreateRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int UserId { get; set; }
    }
}
