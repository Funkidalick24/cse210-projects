using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }


    public void DisplayStartingMessage()
    {   
        Console.Clear();
        Console.Write($"Starting the {_name}. {_description}.\nPlease set the duration (seconds): ");
        string duration = Console.ReadLine();
        _duration = int.Parse(duration);

        Console.WriteLine("Get ready!!!!");

        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("You did a good job");

        ShowSpinner(3);

        Console.WriteLine($"You've completed the {_name}. Which ran for {_duration} seconds");
        ShowSpinner(5);

        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>();
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        
        while(startTime < endTime)
        {   
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if(i >= spinner.Count)
            {
                i = 0;
            }

            startTime = DateTime.Now;
        }

        Console.WriteLine();
    } 

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0 ; i--)
        {   
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}