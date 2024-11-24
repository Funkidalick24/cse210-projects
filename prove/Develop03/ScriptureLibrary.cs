public class ScriptureLibrary
{
    private readonly List<Scripture> _scriptures = [];
    private readonly Random _random = new();

    public void LoadFromFile(string filename)
    {
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length < 2)
            {
                continue;
            }

            string[] referenceParts = parts[0].Split(' ');
            if (referenceParts.Length < 2)
            {
                continue;
            }

            string book = referenceParts[0];
            string[] verseParts = referenceParts[1].Split(':');
            if (verseParts.Length < 2)
            {
                continue;
            }

            if (int.TryParse(verseParts[0], out int chapter))
            {
                Reference reference;
                if (verseParts[1].Contains('-'))
                {
                    string[] verses = verseParts[1].Split('-');
                    if (int.TryParse(verses[0], out int startVerse) &&
                        int.TryParse(verses[1], out int endVerse))
                    {
                        reference = new Reference(book, chapter, startVerse, endVerse);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (int.TryParse(verseParts[1], out int verse))
                    {
                        reference = new Reference(book, chapter, verse);
                    }
                    else
                    {
                        continue;
                    }
                }

                _scriptures.Add(new Scripture(reference, parts[1]));
            }
        }
    }

    public Scripture GetRandomScripture()
    {
        return _scriptures[_random.Next(_scriptures.Count)];
    }

    public int Count => _scriptures.Count;
}