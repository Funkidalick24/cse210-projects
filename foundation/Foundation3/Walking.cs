public class Walking(string name, int duration, double distance) : Activity(name, duration)
{
    private readonly double distance = distance; // in kilometers

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / GetDuration() * 60; // in kilometers per hour
    }

    public override double GetPace()
    {
        return GetDuration() / distance; // in minutes per kilometer
    }
}
