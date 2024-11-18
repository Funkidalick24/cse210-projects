using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }


    public override void RecordEvent()
    {
        if (_checkbox == "[]")
        {
            _checkbox = "[x]";
            Console.WriteLine($"{_shortName} Complete. {_points} points earned");
        }
        else
        {
            Console.WriteLine("Action impossible");
        }
    }

    public override bool IsComplete()
    {
        if (_checkbox == "[x]")
        {
            _isComplete = true;
        }
        else
        {
            _isComplete = false;
        }

        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string data = $"simple|{_checkbox}|{_shortName}|{_description}|{_points}";
        return data;
    }

}