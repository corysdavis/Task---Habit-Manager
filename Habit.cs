/*************************************************************
* Name: Cory Davis
* Date: 12/7/2025
* Assignment: Course Project
* Description: represents a recurring habit
*************************************************************/

public class Habit
{
    public int HabitId { get; set; }
    public string Name { get; set; }
    public int StreakCount { get; private set; }

    public Habit(int id, string name)
    {
        HabitId = id;
        Name = name;
    }

    public void RecordProgress() => StreakCount++;

    public override string ToString() =>
        $"{HabitId}: {Name} (Streak: {StreakCount})";
}