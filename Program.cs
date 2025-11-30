/*************************************************************
* Name: Cory Davis
* Date: 11/30/2025
* Assignment: Course Project
* Description: main application class
*************************************************************/


using System;

public class Program
{
    static void Main()
    {
        TaskManager tManager = new();
        HabitManager hManager = new();
        AchievementManager aManager = new();

        Console.WriteLine("Task & Habit Manager\n");

        bool run = true;
        while (run)
        {
            Console.WriteLine("1) Add Task\n2) Complete Task\n3) Add Habit\n4) Record Habit\n5) View Achievements\n0) Exit");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Task title: ");
                    tManager.AddTask(new TaskItem(tManager.Tasks.Count + 1, Console.ReadLine(), ""));
                    break;
                case "2":
                    Console.Write("Task ID: ");
                    var t = tManager.GetTask(int.Parse(Console.ReadLine()));
                    t?.MarkComplete();
                    if (t != null) aManager.CheckTaskAchievements(t);
                    break;
                case "3":
                    Console.Write("Habit name: ");
                    hManager.AddHabit(new Habit(hManager.Habits.Count + 1, Console.ReadLine()));
                    break;
                case "4":
                    Console.Write("Habit ID: ");
                    var h = hManager.GetHabit(int.Parse(Console.ReadLine()));
                    h?.RecordProgress();
                    if (h != null) aManager.CheckHabitAchievements(h);
                    break;
                case "5":
                    aManager.Achievements.ForEach(a => Console.WriteLine(a));
                    break;
                case "0":
                    run = false;
                    break;
            }
        }
    }
}