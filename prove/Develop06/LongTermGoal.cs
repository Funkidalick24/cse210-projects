public class LongTermGoal(string description, int targetCalories)
{
    private readonly string description = description;
    private readonly int targetCalories = targetCalories;
    private int progress;

    public void AddProgress(int calories)
    {
        progress += calories;
        if (progress >= targetCalories)
        {
            Console.WriteLine("Goal achieved: " + description);
            progress = 0; // Reset progress after achieving goal
        }
    }

    public int GetProgress()
    {
        return progress;
    }
}




