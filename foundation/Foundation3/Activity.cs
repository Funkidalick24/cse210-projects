public abstract class Activity(string name, int duration)
{
    private readonly string name = name;
    private readonly int duration = duration; // duration in minutes

    public string GetName()
    {
        return name;
    }

    public int GetDuration()
    {
        return duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{name} - Duration: {duration} minutes, Distance: {GetDistance():0.00} units, Speed: {GetSpeed():0.00} units/hour, Pace: {GetPace():0.00} minutes/unit";
    }
}
