public abstract class Goal(string name, string description, int points)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public int Points { get; protected set; } = points;
    public bool IsComplete { get; protected set; }

    public abstract void RecordEvent();
    public abstract string GetDetails();
    public abstract string Serialize();
}
