/// <summary>
/// Stores a list of journal entries
/// </summary>
public class Journal
{
    public List<Entry> Entries { get; } = [];

    public void AddEntry(string prompt, string response)
    {
        Entry newEntry = new()
        {
            Date = DateTime.Now.ToShortDateString(),
            PromptText = prompt,
            EntryText = response
        };

        Entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!");

    }

    public void DisplayAll()
    {
        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using StreamWriter outputFile = new(filename);
        foreach (Entry entry in Entries)
        {
            outputFile.WriteLine($"{entry.Date}~|~{entry.PromptText}~|~{entry.EntryText}");
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            Entry entry = new() { Date = parts[0], PromptText = parts[1], EntryText = parts[2] };
            Entries.Add(entry);
        }
    }
}
