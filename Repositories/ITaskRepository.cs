using task_api.Models;

namespace task_api.Repositories;

public interface ITaskRepository
{
    IEnumerable<Tasks> GetAllTasks();
    Tasks? GetTaskById(int TaskId);
    Tasks CreateTask(Tasks newTask);
    Tasks? UpdateTask(Tasks newTask);
    void DeleteTaskById(int TaskId);

}