using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tasks")]
    public class TaskController(ITaskService service) : ControllerBase
    {
        private readonly ITaskService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var task = await _service.CreateTaskAsync(request);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _service.GetTask(id);
            if(task is null)
            {
                return NotFound(new { Message = $"Task with Id {id} not found."});
            }

            return Ok(task);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUserId(int userId)
        {
            var tasks = await _service.GetTasksByUserId(userId);

            if(tasks is null || tasks.Count == 0)
            {
                return NotFound(new { Message = $"No tasks found for User with Id: {userId}" });
            }
            return Ok(tasks);
        }
    }
}
