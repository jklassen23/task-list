using task_api.Models;
using task_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase 
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _TaskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _TaskRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tasks>> GetTasks() 
    {
        return Ok(_TaskRepository.GetAllTasks());
    }

    [HttpGet]
    [Route("{TaskId:int}")]
    public ActionResult<Tasks> GetTaskById(int TaskId) 
    {
        var Task = _TaskRepository.GetTaskById(TaskId);
        if (Task == null) {
            return NotFound();
        }
        return Ok(Task);
    }

    [HttpPost]
    public ActionResult<Tasks> CreateTask(Tasks task) 
    {
        if (!ModelState.IsValid || task == null) {
            return BadRequest();
        }
        var newTask = _TaskRepository.CreateTask(task);
        return Created(nameof(GetTaskById), newTask);
    }

    [HttpPut]
    [Route("{TaskId:int}")]
    public ActionResult<Tasks> UpdateTask(Tasks Task) 
    {
        if (!ModelState.IsValid || Task == null) {
            return BadRequest();
        }
        return Ok(_TaskRepository.UpdateTask(Task));
    }

    [HttpDelete]
    [Route("{TaskId:int}")]
    public ActionResult DeleteTask(int TaskId) 
    {
        _TaskRepository.DeleteTaskById(TaskId); 
        return NoContent();
    }
}
