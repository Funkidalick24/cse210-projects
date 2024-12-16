

public abstract class Activity(string name, string description, ActivityLog activityLog)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    protected int Duration { get; set; }
    protected ActivityLog ActivityLog { get; set; } = activityLog;

    public void StartActivity()
    {
        Console.WriteLine($"Starting: {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Console.WriteLine($"Activity: {Name}");
        Console.WriteLine($"Duration: {Duration} seconds");
        ShowSpinner(3);
        Console.WriteLine("Activity finished.\n");

        ActivityLog.AddEntry($"Activity: {Name}, Duration: {Duration} seconds, Completed at: {DateTime.Now}");
    }

    protected static void ShowSpinner(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void PerformActivity();
}
