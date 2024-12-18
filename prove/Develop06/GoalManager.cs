public class GoalManager
{
    private readonly List<Goal> goals;
    public int Score { get; private set; }

    public GoalManager()
    {
        goals = [];
        Score = 0;
    }

    public void CreateSimpleGoal(string name, string description, int points)
    {
        goals.Add(new SimpleGoal(name, description, points));
    }

    public void CreateEternalGoal(string name, string description, int points)
    {
        goals.Add(new EternalGoal(name, description, points));
    }

    public void CreateChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
    {
        goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            Score += goal.Points;
            if (goal is ChecklistGoal cg && cg.IsComplete)
            {
                Score += cg.BonusPoints;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetails());
        }
    }

    public void SaveGoals(string fileName)
    {
        using StreamWriter writer = new(fileName);
        writer.WriteLine(Score);
        foreach (Goal goal in goals)
        {
            writer.WriteLine(goal.Serialize());
        }
    }

    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            using StreamReader reader = new(fileName);
            Score = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklistGoal = new(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[6]))
                        {
                            CurrentCount = int.Parse(parts[5])
                        };
                        if (bool.Parse(parts[7]))
                        {
                            checklistGoal.RecordEvent();
                        }
                        goals.Add(checklistGoal);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
