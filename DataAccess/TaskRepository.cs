using DataAccess.Models;

namespace DataAccess;

public class TaskRepository
{
    private List<TaskItem> tasks = new()
    {
        new() { Id = 1, Title = "First Task", IsComplete = false },
        new() { Id = 2, Title = "Second Task", IsComplete = false }
    };

    public List<TaskItem> GetAll() => tasks;

    public void Add(TaskItem task) => tasks.Add(task);

    public TaskItem? GetById(int id) => tasks.FirstOrDefault(t => t.Id == id);

    public void Delete(int id)
    {
        TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);

        if(task != null)
        {
            tasks.Remove(task);
        }
    }
}
