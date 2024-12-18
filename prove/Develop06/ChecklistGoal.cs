public class ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : Goal(name, description, points)
{
    public int TargetCount { get; private set; } = targetCount;
    public int CurrentCount { get; set; }
    public int BonusPoints { get; private set; } = bonusPoints;

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsComplete = true;
                Console.WriteLine($"Goal '{Name}' completed! You earned {Points + BonusPoints} points.");
            }
            else
            {
                Console.WriteLine($"Progress made on '{Name}'. You earned {Points} points. Completed {CurrentCount}/{TargetCount} times.");
            }
        }
    }

    public override string GetDetails()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name}: {Description} - {Points} points each time, Bonus: {BonusPoints} points on completion. Completed {CurrentCount}/{TargetCount} times.";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{TargetCount}|{CurrentCount}|{BonusPoints}|{IsComplete}";
    }
}
