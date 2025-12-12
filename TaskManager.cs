/*************************************************************
* Name: Cory Davis
* Date: 12/7/2025
* Assignment: Course Project
* Description: manages the collection of tasks
*************************************************************/

public class TaskManager
{
    private Database db;

    public List<TaskItem> Tasks { get; private set; }

    public TaskManager(Database database)
    {
        db = database;
        Tasks = db.LoadTasks();
    }

    public void AddTask(TaskItem t)
    {
        Tasks.Add(t);
        db.SaveTask(t);
    }

    public TaskItem GetTask(int id) =>
        Tasks.FirstOrDefault(t => t.TaskId == id);
}