using System;

public class ReflectingActivty : Activity
{
    List<string> _prompts;
    List<string> _questions;

    public ReflectingActivty(string name = "Reflecting Activity", string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", int duration = 5) : base(name, description, duration)
    {
         _prompts = new List<string>();
         _questions = new List<string>();
    }


    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        AddPrompts();

        while(startTime < endTime)
        {   
            Console.Clear();
            AddQuestions();

            Console.WriteLine("Please ponder the following:");
            DisplayPrompt();
            ShowSpinner(4);
            
            while(startTime < endTime && _questions.Count > 0)
            {
                DisplayQuestions();
                ShowSpinner(5);
                
                startTime = DateTime.Now;
            }
            startTime = DateTime.Now;
        }

        Console.WriteLine("\n");
        DisplayEndingMessage();
    }

    private List<string> AddPrompts()
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        return _prompts;
    }
    private List<string> AddQuestions()
    {
        _questions.Add("How can you keep this experience in mind in the future?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("How did you get started?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("Why was this experience meaningful to you?");

        return _questions;
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count - 1)];
        
        _prompts.Remove(prompt);
        
        return prompt;
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        string question = _questions[random.Next(_questions.Count - 1)];
        
        _questions.Remove(question);
        
        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("-------------------------------------");

    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }
}