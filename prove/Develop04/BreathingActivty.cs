using System;

public class BreathingActivty : Activity
{
    public BreathingActivty(string name = "Breathing Activity", string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", int duration = 10) : base(name, description, duration)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while(startTime < endTime)
        {
            Console.WriteLine();

            Console.Write($"Breathe in..");
            ShowCountDown(5);

            Console.WriteLine();
            
            Console.Write($"Breathe out..");
            ShowCountDown(5);

            startTime = DateTime.Now;
        }

        Console.WriteLine("\n");
        DisplayEndingMessage();
    }
}