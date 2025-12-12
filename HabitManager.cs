/*************************************************************
* Name: Cory Davis
* Date: 12/7/2025
* Assignment: Course Project
* Description: manages the collection of habits
*************************************************************/

public class HabitManager
{
    private Database db;

    public List<Habit> Habits { get; private set; }

    public HabitManager(Database database)
    {
        db = database;
        Habits = db.LoadHabits();
    }

    public void AddHabit(Habit h)
    {
        Habits.Add(h);
        db.SaveHabit(h);
    }

    public Habit GetHabit(int id) =>
        Habits.FirstOrDefault(h => h.HabitId == id);
}