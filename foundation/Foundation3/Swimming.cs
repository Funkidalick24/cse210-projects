public class Swimming(string name, int duration, int laps) : Activity(name, duration)
{
    private readonly int laps = laps;

    public override double GetDistance()
    {
        return laps * 50 / 1000.0; // in kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetDuration() * 60; // in kilometers per hour
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance(); // in minutes per kilometer
    }
}
