

public class ActivityLog
{
    private List<string> logEntries;

    public ActivityLog()
    {
        logEntries = [];
    }

    public void AddEntry(string entry)
    {
        logEntries.Add(entry);
    }

    public void SaveLog(string filePath)
    {
        File.WriteAllLines(filePath, logEntries);
    }

    public void LoadLog(string filePath)
    {
        logEntries = File.Exists(filePath) ? ([.. File.ReadAllLines(filePath)]) : ([]);
    }

    public void DisplayLog()
    {
        Console.WriteLine("Activity Log:");
        foreach (string entry in logEntries)
        {
            Console.WriteLine(entry);
        }
    }
}
