/*************************************************************
* Name: Cory Davis
* Date: 11/30/2025
* Assignment: Course Project
* Description: manages the collection of tasks
*************************************************************/

public class TaskManager
{
    public List<TaskItem> Tasks { get; private set; } = new();

    public void AddTask(TaskItem t) => Tasks.Add(t);

    public TaskItem GetTask(int id) =>
        Tasks.FirstOrDefault(t => t.TaskId == id);
}