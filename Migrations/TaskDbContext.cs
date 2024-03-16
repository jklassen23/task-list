using task_api.Models;
using Microsoft.EntityFrameworkCore;

namespace task_api.Migrations;

public class TaskDbContext : DbContext
{
    public DbSet<Tasks> Task { get; set; }
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.taskId);
            entity.Property(e => e.taskName).IsRequired();
            entity.Property(e => e.completion).IsRequired();
        });

        modelBuilder.Entity<Tasks>().HasData(
            new Tasks { 
                taskId = 1,
                taskName = "Get milk",
                completion = true
                
            },
            new Tasks { 
                taskId = 2,
                taskName = "drink milk",
                completion = false
            }
        );
    }
}