

public class GratitudeActivity(ActivityLog activityLog) : Activity(
    "Gratitude Activity",
    "This activity will help you practice gratitude by reflecting on the things you are thankful for in your life.",
    activityLog
    )
{
    private static readonly List<string> GratitudePrompts =
    [
        "Think of a person you are grateful for.",
        "Think of an experience you are grateful for.",
        "Think of a place you are grateful for.",
        "Think of a skill or talent you are grateful for."
    ];

    public override void PerformActivity()
    {
        StartActivity();
        Random random = new();
        string prompt = GratitudePrompts[random.Next(GratitudePrompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(5);
        EndActivity();
    }
}
