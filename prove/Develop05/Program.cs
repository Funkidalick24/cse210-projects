
/*
    Enhanced the program by adding an `ActivityLog` class to track and display activity history, including saving and loading log data. 
    Improved the `BreathingActivity` with a visual breathing animation for a better user experience. 
    Ensured unique prompts/questions and organized code into separate files for better maintainability.
*/

ActivityLog activityLog = new();
activityLog.LoadLog("activity_log.txt");

Dictionary<string, Activity> activities = new()
{
            { "1", new BreathingActivity(activityLog) },
            { "2", new ReflectionActivity(activityLog) },
            { "3", new ListingActivity(activityLog) }
        };

while (true)
{
    Console.WriteLine("Choose an activity:");
    Console.WriteLine("1. Breathing Activity");
    Console.WriteLine("2. Reflection Activity");
    Console.WriteLine("3. Listing Activity");
    Console.WriteLine("4. View Activity Log");
    Console.WriteLine("5. Quit");

    string choice = Console.ReadLine();
    if (choice == "5")
    {
        activityLog.SaveLog("activity_log.txt");
        break;
    }

    if (choice == "4")
    {
        activityLog.DisplayLog();
    }
    if (activities.TryGetValue(choice, out Activity activity))
    {
        activity.PerformActivity();
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }

}
