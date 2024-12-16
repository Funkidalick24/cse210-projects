

public class BreathingActivity(ActivityLog activityLog) : Activity(
    "Breathing Activity",
    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
    activityLog
    )
{
    public override void PerformActivity()
    {
        StartActivity();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            ShowBreathingAnimation("Breathe in...", 3);
            ShowBreathingAnimation("Breathe out...", 3);
        }
        EndActivity();
    }

    private static void ShowBreathingAnimation(string message, int duration)
    {
        Console.Clear();
        Console.WriteLine(message);
        int steps = 20;
        int stepDuration = duration * 1000 / steps;
        for (int i = 0; i <= steps; i++)
        {
            Console.SetCursorPosition(0, 1);
            int width = i * 50 / steps;
            Console.Write("[" + new string('=', width) + new string(' ', 50 - width) + "]");
            Thread.Sleep(stepDuration);
        }
        Console.Clear();
    }
}
