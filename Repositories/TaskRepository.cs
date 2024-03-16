using task_api.Migrations;
using task_api.Models;

namespace task_api.Repositories;

public class TaskRepository : ITaskRepository 
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public Tasks CreateTask(Tasks newTask)
    {
        _context.Task.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public void DeleteTaskById(int TaskId)
    {
        var Task = _context.Task.Find(TaskId);
        if (Task != null) {
            _context.Task.Remove(Task); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<Tasks> GetAllTasks()
    {
        return _context.Task.ToList();
    }
    public Tasks? GetTaskById(int TaskId)
    {
        return _context.Task.SingleOrDefault(c => c.taskId == TaskId);
    }
    public Tasks? UpdateTask(Tasks newTask)
    {
        var originalTask = _context.Task.Find(newTask.taskId);
        if (originalTask != null) {
            originalTask.taskName = newTask.taskName;
            originalTask.completion = newTask.completion;
            _context.SaveChanges();
        }
        return originalTask;
    }
}