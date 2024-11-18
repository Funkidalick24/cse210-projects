using System;

public class ListingActivity : Activity
{
    private int _count = 0;
    private List<string> _prompts;

    public ListingActivity(string name = "Listing Activity", string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", int duration = 60) : base(name, description, duration)
    {
        _prompts = new List<string>();
    }


    public void Run()
    {
        DisplayStartingMessage();

        AddPrompts();
        Console.WriteLine(GetRandomPrompt());
        Console.Write("Consider the prompt, then respond with as many entries as you can...");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Console.WriteLine("\nBegin!!!");
        
        while(startTime < endTime)
        {
            GetListFromUser();
            _count++;

            startTime = DateTime.Now;
        }
        Console.WriteLine($"{_count} items entered.");


        Console.WriteLine("\n");
        DisplayEndingMessage();
    }

    private List<string> AddPrompts()
    {
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("Who are some of your personal heroes?");

        return _prompts;
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count - 1)];
        
        _prompts.Remove(prompt);
        
        return prompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();

        string entry = Console.ReadLine();
        list.Add(entry);
        return list;
    }

}