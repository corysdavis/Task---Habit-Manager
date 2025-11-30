/*************************************************************
* Name: Cory Davis
* Date: 11/30/2025
* Assignment: Course Project
* Description: represents a single task with details, completion state and formatting
*************************************************************/

public class TaskItem
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; private set; }

    public TaskItem(int id, string title, string description)
    {
        TaskId = id;
        Title = title;
        Description = description;
    }

    public void MarkComplete() => IsCompleted = true;

    public override string ToString() =>
        $"{TaskId}: {Title} (Done: {IsCompleted})";
}