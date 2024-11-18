using System;
using System.ComponentModel;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;


    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public void Start()
    {
        bool run;

        do
        {
            run = true;
            Console.WriteLine($"You have {_score} points\n");

            Console.Write("Menu Options:\n1. Create Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit\n> ");
            string optn = Console.ReadLine();

            if (optn == "1")
            {
                Console.WriteLine();
                CreateGoal();
            }
            else if (optn == "2")
            {
                Console.WriteLine("The goals are: ");
                ListGoalDetails();
            }
            else if (optn == "3")
            {
                SaveGoals();
            }
            else if (optn == "4")
            {
                LoadGoals();
            }
            else if (optn == "5")
            {
                RecordEvent();
            }
            else if (optn == "6")
            {
                run = false;
            }

            Console.WriteLine();

        } while (run);
    }

    public void DisplayPlayerInfo()
    {
        int count = 0;

        // Displays each completed goal and the points earned.
        Console.WriteLine("Goals completed:");
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                count++;
                Console.WriteLine($"{count}. {goal.GetDetailsString()}");
            }
        }

        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        int count = 0;
        foreach (Goal goal in _goals)
        {
            count++;
            Console.WriteLine($"{count}. {goal.GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        int count = 0;
        foreach (Goal goal in _goals)
        {
            count++;
            Console.WriteLine($"{count}. {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        // Declare variables to be used later
        string name = "";
        string desc = "";
        int points = 0;
        int target = 0;
        int bonus = 0;

        Console.WriteLine("What type of Goal would You like to add?\n1. Simple\n2. Eternal\n3. Checklist ");
        Console.Write(">");
        string type = Console.ReadLine();

        // Creates a goal depending on the type chosen and adds it to a list of goals
        if (type == "1")
        {
            Console.Write("Give a short name for your goal.\n> ");
            name = Console.ReadLine();
            Console.Write("Give a description for your goal.\n> ");
            desc = Console.ReadLine();
            Console.Write("Points upon conquering the goal.\n> ");
            string point = Console.ReadLine();

            points = int.Parse(point);

            SimpleGoal simple = new SimpleGoal(name, desc, points);
            _goals.Add(simple);

            Console.WriteLine($"{name} goal added");
        }
        else if (type == "2")
        {
            Console.Write("Give a short name for your goal.\n> ");
            name = Console.ReadLine();
            Console.Write("Give a description for your goal.\n> ");
            desc = Console.ReadLine();
            Console.Write("Points every time the goal is accomplished.\n> ");
            string point = Console.ReadLine();

            points = int.Parse(point);

            EternalGoal eternal = new EternalGoal(name, desc, points);
            _goals.Add(eternal);

            Console.WriteLine($"{name} goal added");
        }
        else if (type == "3")
        {
            Console.Write("Give a short name for your goal.\n> ");
            name = Console.ReadLine();
            Console.Write("Give a description for your goal.\n> ");
            desc = Console.ReadLine();
            Console.Write("Points for each completion.\n> ");
            string point = Console.ReadLine();
            Console.Write("Number of times to completely complete goal in its completeness.\n> ");
            string targt = Console.ReadLine();
            Console.Write("Bonus points upon conquering the goal.\n> ");
            string bns = Console.ReadLine();

            points = int.Parse(point);
            target = int.Parse(targt);
            bonus = int.Parse(bns);

            ChecklistGoal checklist = new ChecklistGoal(name, desc, points, target, bonus);
            _goals.Add(checklist);

            Console.WriteLine($"{name} goal added");
        }

        Console.WriteLine();
    }

    public void RecordEvent()
    {
        // number of goals
        int count = 0;

        Console.WriteLine("Please choose one of the following: ");
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete() == false)
            {
                count++;
                Console.WriteLine($"{count}. {goal.GetName()}");
            }
        }

        Console.Write("\n> ");
        string idx = Console.ReadLine();

        int indx = int.Parse(idx) - 1;

        // Records event and adds points to score
        _goals[indx].RecordEvent();
        _score += _goals[indx].GetPoints();
    }

    public void SaveGoals()
    {
        Console.Write("Enter file name:\n>");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"{fileName} saved");
    }

    public void LoadGoals()
    {
        Console.Write("Enter file name:\n>");
        string fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            string type = parts[0];

            if (parts.Length < 6)
            {
                string check = parts[1];
                string name = parts[2];
                string desc = parts[3];
                string pnt = parts[4];
                int points = int.Parse(pnt);

                if (type == "simple")
                {
                    SimpleGoal simple = new SimpleGoal(name, desc, points);
                    simple.SetCheckbox(check);
                    _goals.Add(simple);
                }
                else if (type == "eternal")
                {
                    EternalGoal eternal = new EternalGoal(name, desc, points);
                    eternal.SetCheckbox(check);
                    _goals.Add(eternal);
                }
            }
            else
            {
                string complted = parts[1];
                string targt = parts[2];
                string name = parts[3];
                string desc = parts[4];
                string pnt = parts[5];
                string bns = parts[6];

                int completed = int.Parse(complted);
                int target = int.Parse(targt);
                int points = int.Parse(pnt);
                int bonus = int.Parse(bns);

                if (type == "checklist")
                {
                    ChecklistGoal checklist = new ChecklistGoal(name, desc, points, target, bonus);
                    checklist.SetAmountCompleted(completed);
                    _goals.Add(checklist);

                }
            }
        }
    }
}