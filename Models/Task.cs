using System.ComponentModel.DataAnnotations;

namespace task_api.Models;

public class Tasks 
{
    public int taskId { get; set; }
    [Required]
    public string? taskName { get; set; }
    [Required]

    public Boolean completion { get; set; }

}