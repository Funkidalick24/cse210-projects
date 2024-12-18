

public class EternalGoal(string name, string description, int points) : Goal(name, description, points)
{
    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for '{Name}'. You earned {Points} points.");
    }

    public override string GetDetails()
    {
        return $"[ ] {Name}: {Description} - {Points} points each time";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}
