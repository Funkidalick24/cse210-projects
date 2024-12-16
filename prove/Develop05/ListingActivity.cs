

public class ListingActivity(ActivityLog activityLog) : Activity(
 "Listing Activity",
 "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
 activityLog
)
{
    private static readonly List<string> Prompts =
    [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];

    public override void PerformActivity()
    {
        StartActivity();
        List<string> usedPrompts = [];
        Random random = new();
        while (usedPrompts.Count < Prompts.Count)
        {
            string prompt = Prompts[random.Next(Prompts.Count)];
            if (!usedPrompts.Contains(prompt))
            {
                usedPrompts.Add(prompt);
                Console.WriteLine(prompt);
                ShowSpinner(5);
                Console.WriteLine("Start listing items:");
                DateTime startTime = DateTime.Now;
                List<string> items = [];
                while ((DateTime.Now - startTime).TotalSeconds < Duration)
                {
                    string item = Console.ReadLine();
                    items.Add(item);
                }
                Console.WriteLine($"You listed {items.Count} items.");
                EndActivity();
            }
        }
    }
}
