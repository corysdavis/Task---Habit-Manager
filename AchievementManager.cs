/*************************************************************
* Name: Cory Davis
* Date: 12/7/2025
* Assignment: Course Project
* Description: manages all user achievements
*************************************************************/

public class AchievementManager
{
    private Database db;

    public List<Achievement> Achievements { get; private set; }

    public AchievementManager(Database database)
    {
        db = database;
        Achievements = db.LoadAchievements();
    }

    public void Add(Achievement a)
    {
        Achievements.Add(a);
        db.SaveAchievement(a);
    }

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
}