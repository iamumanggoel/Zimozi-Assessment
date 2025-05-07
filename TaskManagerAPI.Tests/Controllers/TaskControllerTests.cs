using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Controllers;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Tests.Controllers
{
    [TestFixture]
    public class TaskControllerTests
    {
        private Mock<ITaskService> _taskServiceMock;
        private TaskController _taskController;

        [SetUp]
        public void SetUp()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _taskController = new TaskController(_taskServiceMock.Object);
        }

        //Valid: Task Created
        [Test]
        public async Task CreateTask_ValidRequest_ReturnsSuccess()
        {
            var req = new TaskCreateRequest { Title = "Test", UserId = 1 };
            var task = new TaskResponse { Id = 1, Title = "Test", UserId = 1 };

            _taskServiceMock.Setup(s => s.CreateTaskAsync(req)).ReturnsAsync(task);

            var response = await _taskController.CreateTask(req) as CreatedAtActionResult;


            Assert.That(response, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(201));
                Assert.That(response.Value, Is.EqualTo(task));
            });
        }

        //InValid: Wrong Model State. Usually won't occur
        [Test]
        public async Task CreateTask_InvalidModelState_ReturnsBadRequest()
        {
            _taskController.ModelState.AddModelError("Title", "Title is required");

            var response = await _taskController.CreateTask(new TaskCreateRequest { Title = "Test", UserId = 1 }) as BadRequestObjectResult;

            Assert.That(response, Is.Not.Null);
            Assert.That(response?.StatusCode, Is.EqualTo(400));
        }

        //Valid: Task Found by Id
        [Test]
        public async Task GetTaskById_TaskExists_ReturnsSuccess()
        {
            var task = new TaskResponse { Id = 1, Title = "Task", UserId = 1 };

            _taskServiceMock.Setup(s => s.GetTask(1)).ReturnsAsync(task);

            var response = await _taskController.GetTaskById(1) as OkObjectResult;

            Assert.That(response, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(200));
                Assert.That(response.Value, Is.EqualTo(task));
            });
        }

        //InValid: No Task with Given Id
        [Test]
        public async Task GetTaskById_TaskNotExists_ReturnsFailure()
        {
            _taskServiceMock.Setup(s => s.GetTask(2)).ReturnsAsync((TaskResponse?) null);

            var response = await _taskController.GetTaskById(2) as NotFoundObjectResult;

            Assert.That(response?.Value?.ToString(), Does.Contain("Task with Id 2 not found"));
            Assert.That(response?.StatusCode, Is.EqualTo(404));
        }

        //Valid: Tasks Found with Given Id
        [Test]
        public async Task GetTasksByUserId_TaskExists_ReturnsSuccess()
        {
            var tasks = new List<TaskResponse>
            {
                new() { Id = 1, Title = "Task 1", UserId = 1 },
                new() { Id = 2, Title = "Task 2", UserId = 1 }
            };

            _taskServiceMock.Setup(s => s.GetTasksByUserId(1)).ReturnsAsync(tasks);

            var response = await _taskController.GetTasksByUserId(1) as OkObjectResult;

            Assert.That(response, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(200));
                Assert.That(response.Value, Is.EqualTo(tasks));
            });

        }

        //InValid: Tasks not found with Given Id
        [Test]
        public async Task GetTasksByUserId_TaskNotExists_ReturnsFailure()
        {
            _taskServiceMock.Setup(s => s.GetTasksByUserId(1)).ReturnsAsync([]);

            var response = await _taskController.GetTasksByUserId(1) as NotFoundObjectResult;
            Assert.That(response?.Value?.ToString(), Does.Contain("No tasks found for User with Id: 1"));
            Assert.That(response?.StatusCode, Is.EqualTo(404));

        }
    }
}
