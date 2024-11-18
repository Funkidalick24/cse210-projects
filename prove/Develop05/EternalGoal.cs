using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override void RecordEvent()
    {
        Console.WriteLine($"{_shortName} Completed. {_points} points earned.");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        string data = $"eternal|{_checkbox}|{_shortName}|{_description}|{_points}";
        return data;
    }

}