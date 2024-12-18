// Create activities
Activity walk = new Walking("Morning Walk", 30, 2.5);
Activity run = new Running("Evening Run", 45, 8);
Activity swim = new Swimming("Swimming Laps", 60, 40);

// Add activities to a list
List<Activity> activities = [walk, run, swim];

// Iterate through the list and display the summary for each activity
foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}
