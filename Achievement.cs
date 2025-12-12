/*************************************************************
* Name: Cory Davis
* Date: 12/7/2025
* Assignment: Course Project
* Description: represents an achievement that a user can earn
*************************************************************/

public class Achievement
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Achievement(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public override string ToString() => $"{Title}: {Description}";
}