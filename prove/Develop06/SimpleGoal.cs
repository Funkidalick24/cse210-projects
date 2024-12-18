
public class SimpleGoal(string name, string description, int points) : Goal(name, description, points)
{
    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
    }

    public override string GetDetails()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name}: {Description} - {Points} points";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{IsComplete}";
    }
}
