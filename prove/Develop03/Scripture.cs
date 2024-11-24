public class Scripture(Reference reference, string text)
{
    private readonly Reference _reference = reference;
    private readonly List<Word> _words = text.Split(' ').Select(word => new Word(word)).ToList();
    private readonly Random _random = new();
    private int _attempts;
    private DateTime _startTime;

    public void HideRandomWords(int numberToHide)
    {
        _attempts++;
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public string GetHintText()
    {
        return $"{_reference.GetDisplayText()}\n" + string.Join(" ", _words.Select(w => w.GetText()[0] + new string('.', w.GetText().Length - 1)));
    }

    public void HideEveryNthWord(int n)
    {
        for (int i = n - 1; i < _words.Count; i += n)
        {
            _words[i].Hide();
        }
    }

    public void HideWordsByLength(int minLength)
    {
        foreach (Word word in _words.Where(w => !w.IsHidden() && w.GetText().Length >= minLength))
        {
            word.Hide();
        }
    }

    public void StartTracking()
    {
        _attempts = 0;
        _startTime = DateTime.Now;
    }

    public string GetStats()
    {
        TimeSpan duration = DateTime.Now - _startTime;
        return $"\nStatistics:\nAttempts: {_attempts}\nTime spent: {duration.Minutes}m {duration.Seconds}s";
    }
}
