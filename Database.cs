/*************************************************************
* Name: Cory Davis
* Date: 12/7/2025
* Assignment: Course Project
* Description:
*************************************************************/

using System.Collections.Generic;
using System.Data.SQLite;

public class Database
{
    private const string Conn = "Data Source=project.db;Version=3;";

    public Database()
    {
        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        string sql = @"
        CREATE TABLE IF NOT EXISTS Tasks (
            TaskId INTEGER PRIMARY KEY,
            Title TEXT,
            Description TEXT,
            IsCompleted INTEGER
        );

        CREATE TABLE IF NOT EXISTS Habits (
            HabitId INTEGER PRIMARY KEY,
            Name TEXT,
            StreakCount INTEGER
        );

        CREATE TABLE IF NOT EXISTS Achievements (
            Title TEXT PRIMARY KEY,
            Description TEXT
        );";

        using var cmd = new SQLiteCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }

    // save methods
    public void SaveTask(TaskItem t)
    {
        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        string sql = "INSERT OR REPLACE INTO Tasks VALUES (@id, @title, @desc, @done);";

        using var cmd = new SQLiteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", t.TaskId);
        cmd.Parameters.AddWithValue("@title", t.Title);
        cmd.Parameters.AddWithValue("@desc", t.Description);
        cmd.Parameters.AddWithValue("@done", t.IsCompleted ? 1 : 0);
        cmd.ExecuteNonQuery();
    }

    public void SaveHabit(Habit h)
    {
        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        string sql = "INSERT OR REPLACE INTO Habits VALUES (@id, @name, @streak);";

        using var cmd = new SQLiteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", h.HabitId);
        cmd.Parameters.AddWithValue("@name", h.Name);
        cmd.Parameters.AddWithValue("@streak", h.StreakCount);
        cmd.ExecuteNonQuery();
    }

    public void SaveAchievement(Achievement a)
    {
        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        string sql = "INSERT OR IGNORE INTO Achievements VALUES (@title, @desc);";

        using var cmd = new SQLiteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@title", a.Title);
        cmd.Parameters.AddWithValue("@desc", a.Description);
        cmd.ExecuteNonQuery();
    }

    // load methods

    public List<TaskItem> LoadTasks()
    {
        List<TaskItem> list = new();

        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        using var cmd = new SQLiteCommand("SELECT * FROM Tasks;", conn);
        using var r = cmd.ExecuteReader();

        while (r.Read())
        {
            var t = new TaskItem(r.GetInt32(0), r.GetString(1), r.GetString(2));
            if (r.GetInt32(3) == 1) t.MarkComplete();
            list.Add(t);
        }

        return list;
    }

    public List<Habit> LoadHabits()
    {
        List<Habit> list = new();

        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        using var cmd = new SQLiteCommand("SELECT * FROM Habits;", conn);
        using var r = cmd.ExecuteReader();

        while (r.Read())
        {
            var h = new Habit(r.GetInt32(0), r.GetString(1));
            h.GetType().GetProperty("StreakCount")?.SetValue(h, r.GetInt32(2));
            list.Add(h);
        }

        return list;
    }

    public List<Achievement> LoadAchievements()
    {
        List<Achievement> list = new();

        using var conn = new SQLiteConnection(Conn);
        conn.Open();

        using var cmd = new SQLiteCommand("SELECT * FROM Achievements;", conn);
        using var r = cmd.ExecuteReader();

        while (r.Read())
        {
            list.Add(new Achievement(r.GetString(0), r.GetString(1)));
        }

        return list;
    }
}
