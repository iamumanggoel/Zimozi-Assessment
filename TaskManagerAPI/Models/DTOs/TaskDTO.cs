using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models.DTOs
{
    public class TaskCreateRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int UserId { get; set; }
    }

    public class TaskResponse: TaskCreateRequest
    { 
        public required int Id { get; set; }
        public List<CommentsResponse>? Comments { get; set; }
    }

    public class CommentsResponse
    {
        public string? Content { get; set; }
    }


}
