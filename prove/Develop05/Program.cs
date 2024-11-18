// Added logic to handle some possuble exceptions
using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop05 World!");

        // SimpleGoal simple = new SimpleGoal("Fart", "Fart for 20 seconds straight", 20);
        // simple.RecordEvent();
        // Console.WriteLine(simple.IsComplete());
        // Console.WriteLine(simple.GetDetailsString());

        // EternalGoal eternal = new EternalGoal("Fight the templars", "Perform an activity which disrupts Templar plans", 10);
        // eternal.RecordEvent();
        // Console.WriteLine(eternal.IsComplete());
        // Console.WriteLine(eternal.GetDetailsString());

        // ChecklistGoal checklist = new ChecklistGoal("Reflection", "Reflect on a past action", 20, 5, 200);
        // checklist.RecordEvent();
        // Console.WriteLine(checklist.IsComplete());
        // Console.WriteLine(checklist.GetDetailsString());

        GoalManager manager = new GoalManager();
        bool run = true;
        bool quit;

        do
        {
            manager.Start();

            Console.Write("Are you sure you want to quit? (yes/no)\n>  ");
            string rsp = Console.ReadLine();

            do
            {
                quit = true;

                if (rsp.ToLower() == "yes")
                {
                    run = false;
                    Console.WriteLine("\nThanks for indulging the collective");
                }
                else if (rsp.ToLower() == "no")
                {
                    run = true;
                }
                else
                {
                    Console.Write("Invalid response, choose between (yes) and (no)\n>");
                    rsp = Console.ReadLine();
                    quit = false;
                }
            } while (!quit);

        } while (run);
    }
}