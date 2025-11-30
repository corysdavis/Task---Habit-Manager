/*************************************************************
* Name: Cory Davis
* Date: 11/30/2025
* Assignment: Course Project
* Description: manages all user achievements
*************************************************************/

using System.Collections.Generic;

public class AchievementManager
{
    public List<Achievement> Achievements { get; private set; } = new();

    public void CheckTaskAchievements(TaskItem t)
    {
        if (t.IsCompleted && !Has("First Task"))
            Add(new Achievement("First Task", "Completed your first task."));
    }

    public void CheckHabitAchievements(Habit h)
    {
        if (h.StreakCount == 5 && !Has("5 Streak"))
            Add(new Achievement("5 Streak", "Reached a streak of 5."));
    }

    private bool Has(string title) =>
        Achievements.Exists(a => a.Title == title);

    private void Add(Achievement a) =>
        Achievements.Add(a);
}