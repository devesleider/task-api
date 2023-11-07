using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Core.DTOs;
using Task.Core.Interfaces;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksByUser(int user, int categorie) {
            return Ok(await _taskRepository.GetTasksByUser(user, categorie));       
        }

        [HttpPost]
        public async Task<IActionResult> Save(TaskDto task)
        {
            return Ok(await _taskRepository.Save(task));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, bool end)
        {
            return Ok(await _taskRepository.Update(id, end));
        }
    }
}
