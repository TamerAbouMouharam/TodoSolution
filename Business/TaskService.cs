using DataAccess;
using DataAccess.Models;

namespace Business;

public class TaskService
{
    private readonly TaskRepository repository;

    public TaskService(TaskRepository repository) => this.repository = repository;

    public List<TaskItem> GetTasks() => repository.GetAll();

    public void AddTask(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
        {
            return;
        }

        List<TaskItem> tasks = repository.GetAll();
        TaskItem task = new() 
        { 
            Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1,
            Title = title, 
            IsComplete = false 
        };
        repository.Add(task);
    }

    public void CompleteTask(int Id)
    {
        TaskItem? task = repository.GetById(Id);

        if(task != null)
        {
            task.IsComplete = true;
        }
    }
}
