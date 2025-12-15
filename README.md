# Task & Habit Manager

## Project Overview
The **Task & Habit Manager** is a console-based application that allows users to manage tasks, track daily habits, and earn achievements. Data is persisted using a SQLite database.

## Features
- Add and complete tasks  
- Add habits and record daily progress  
- Track habit streaks  
- Unlock achievements based on milestones  
- Persistent storage with SQLite  

## Class Structure
- **TaskItem**: Represents a task with title, description, and completion status.  
- **TaskManager**: Manages tasks and interacts with the database.  
- **Habit**: Represents a habit and tracks streak count.  
- **HabitManager**: Manages habits and interacts with the database.  
- **Achievement**: Represents an achievement with a title and description.  
- **AchievementManager**: Manages achievements and checks milestones.  
- **Database**: Handles SQLite operations for tasks, habits, and achievements.  
