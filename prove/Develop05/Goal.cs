using System;
using System.ComponentModel;
using System.ComponentModel.Design;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected string _checkbox = "[]";


    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }


    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string details = $"{_checkbox}{_shortName} ({_description})";
        return details;
    }

    public abstract string GetStringRepresentation();

    public virtual int GetPoints()
    {
        return _points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public void SetCheckbox(string checkbox)
    {
        _checkbox = checkbox;
    }

}