using Api.Modules.TaskModule.Domain.Entities;
using Api.Modules.TaskModule.Domain.Repository;
using Api.Modules.TaskModule.Domain.Repository.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Api.Modules.TaskModule.HTTP
{
    [Route("api/task")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto task)
        {
            var result = await _taskRepository.Create(task);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskRepository.FindById(id);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound("Task not found");
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto task)
        {
            var result = await _taskRepository.Update(task);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var result = await _taskRepository.Delete(id);
            return Ok(result);
        }



        [HttpGet("allByUser")]
        public async Task<IActionResult> GetAllTasksByUser(Guid userId)
        {
            var tasks = await _taskRepository.FindByUser(userId);
            return Ok(tasks);
        }

        [HttpGet("allByTitle")]
        public async Task<IActionResult> GetTasksByTitle(string title, Guid userId)
        {
            var tasks = await _taskRepository.FindByTitle(title, userId);
            return Ok(tasks);
        }

        [HttpGet("allByStatus")]
        public async Task<IActionResult> GetTasksByStatus(EnumStatusTask status, Guid userId)
        {
            var tasks = await _taskRepository.FindByStatus(status, userId);
            return Ok(tasks);
        }

        [HttpGet("allByDate")]
        public async Task<IActionResult> GetTasksByDate(DateTime date, Guid userId)
        {
            var tasks = await _taskRepository.FindByDate(date, userId);
            return Ok(tasks);
        }


    }
}