

/*
    Ensured unique prompts/questions and organized code into separate files for better maintainability.
    Added gamification elements such as badges, levels, and rewards for achieving goals.
*/

GoalManager goalManager = new();

while (true)
{
    Console.WriteLine("1. Create Simple Goal");
    Console.WriteLine("2. Create Eternal Goal");
    Console.WriteLine("3. Create Checklist Goal");
    Console.WriteLine("4. Record Event");
    Console.WriteLine("5. Display Goals");
    Console.WriteLine("6. Save Goals");
    Console.WriteLine("7. Load Goals");
    Console.WriteLine("8. Quit");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());
            goalManager.CreateSimpleGoal(name, description, points);
            break;
        case "2":
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Description: ");
            description = Console.ReadLine();
            Console.Write("Points: ");
            points = int.Parse(Console.ReadLine());
            goalManager.CreateEternalGoal(name, description, points);
            break;
        case "3":
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Description: ");
            description = Console.ReadLine();
            Console.Write("Points: ");
            points = int.Parse(Console.ReadLine());
            Console.Write("Target Count: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Bonus Points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            goalManager.CreateChecklistGoal(name, description, points, targetCount, bonusPoints);
            break;
        case "4":
            Console.Write("Goal Name: ");
            string goalName = Console.ReadLine();
            goalManager.RecordEvent(goalName);
            break;
        case "5":
            goalManager.DisplayGoals();
            break;
        case "6":
            Console.Write("File Name to Save: ");
            string saveFile = Console.ReadLine();
            goalManager.SaveGoals(saveFile);
            break;
        case "7":
            Console.Write("File Name to Load: ");
            string loadFile = Console.ReadLine();
            goalManager.LoadGoals(loadFile);
            break;
        case "8":
            return;
        default:
            break;

    }

}
