using Moq;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Repositories;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Tests.Services
{
    [TestFixture]
    public class TaskServiceTests
    {

        private Mock<ITaskRepository> _mockRepo;
        private TaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<ITaskRepository>();
            _taskService = new TaskService(_mockRepo.Object);
        }

        [Test]
        public async Task CreateTask_ValidRequest_ReturnsSuccess()
        {
            var req = new TaskCreateRequest
            {
                Title = "Test 1",
                Description = "Test Descrption",
                UserId = 1
            };

            var saved = new TaskEntity
            {
                Id = 1,
                Title = req.Title,
                Description = req.Description,
                UserId = req.UserId
            };

            _mockRepo
                .Setup(r => r.AddTaskAsync(It.IsAny<TaskEntity>()))
                .ReturnsAsync(saved);

            var response = await _taskService.CreateTaskAsync(req);

            Assert.Multiple(() =>
            {
                Assert.That(response.Id, Is.EqualTo(saved.Id));
                Assert.That(response.Title, Is.EqualTo(saved.Title));
                Assert.That(response.UserId, Is.EqualTo(saved.UserId));
            });
        }


        [Test]
        public async Task GetTask_TaskExists_ReturnsSuccess()
        {
            var task = new TaskEntity { Id = 1, Title = "Test 1", UserId = 1, Comments = [] };
            _mockRepo.Setup(r => r.GetTask(1)).ReturnsAsync(task);

            var result = await _taskService.GetTask(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Id, Is.EqualTo(task?.Id));
        }

        [Test]
        public async Task GetTask_TaskNotExists_ReturnsFailure()
        {
            _mockRepo.Setup(r => r.GetTask(1)).ReturnsAsync((TaskEntity?) null);

            var result = await _taskService.GetTask(1);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetTasksByUserId_Valid_ReturnsSuccess()
        {
            var tasks = new List<TaskEntity>
            {
                new() { Id = 1, Title = "Test 1", UserId = 1 },
                new() { Id = 2, Title = "Test 2", UserId = 1 }
            };

            _mockRepo.Setup(r => r.GetTasksByUserId(1)).ReturnsAsync(tasks);

            var result = await _taskService.GetTasksByUserId(1);

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0].UserId, Is.EqualTo(1));
        }

        [Test]
        public async Task GetTasksByUserId_NoTasks_ReturnsEmpty()
        {
            _mockRepo.Setup(r => r.GetTasksByUserId(1)).ReturnsAsync([]);

            var result = await _taskService.GetTasksByUserId(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }
    }
}
