using System;
using System.Runtime.CompilerServices;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;


    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }


    public override void RecordEvent()
    {
        _amountCompleted++;

        if (_amountCompleted < _target)
        {
            Console.WriteLine($"{_shortName} recorded [{_amountCompleted}/{_target}]. {_points} points awarded");
        }
        else if (_amountCompleted == _target)
        {
            Console.WriteLine($"{_shortName} recorded [{_amountCompleted}/{_target}]. {_points} points awarded\n{_shortName} Goal completed, {_bonus} bonus points awarded.");
        }
        else if (_amountCompleted > _target)
        {
            _amountCompleted--;

            Console.WriteLine($"You have already completed the {_shortName} Goal.");
        }
    }

    public override int GetPoints()
    {
        if (_amountCompleted == _target)
        {
            _points += _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public override string GetDetailsString()
    {
        string details = $"[{_amountCompleted}/{_target}]{_shortName} ({_description})";
        return details;
    }

    public override string GetStringRepresentation()
    {
        string data = $"checklist|{_amountCompleted}|{_target}|{_shortName}|{_description}|{_points}|{_bonus}";
        return data;
    }

    public void SetAmountCompleted(int num)
    {
        _amountCompleted = num;
    }

}