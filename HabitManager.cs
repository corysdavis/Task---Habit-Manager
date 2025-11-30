/*************************************************************
* Name: Cory Davis
* Date: 11/30/2025
* Assignment: Course Project
* Description: manages the collection of habits
*************************************************************/

using System.Collections.Generic;
using System.Linq;

public class HabitManager
{
    public List<Habit> Habits { get; private set; } = new();

    public void AddHabit(Habit h) => Habits.Add(h);

    public Habit GetHabit(int id) =>
        Habits.FirstOrDefault(h => h.HabitId == id);
}