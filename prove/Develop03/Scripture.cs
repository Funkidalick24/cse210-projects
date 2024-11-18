public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
        string[] split = text.Split(" ");

        foreach (string str in split)
        {
            Word word = new Word(str);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            int indx;
            indx = random.Next(_words.Count);
            if (IsCompletelyHidden())
            {
                break;
            }
            else if (_words[indx].IsHidden())
            {
                do
                {
                    if (IsCompletelyHidden())
                    {
                        break;
                    }

                    indx = random.Next(_words.Count);
                } while (_words[indx].IsHidden());

                _words[indx].Hide();
            }
            else if (_words[indx].IsHidden() == false)
            {
                _words[indx].Hide();
            }
        }
    }

    public string GetDisplayText()
    {
        string text = "";

        foreach (Word word in _words)
        {
            text += $" {word.GetDisplayText()}";
        }

        string scripture = $"{_reference.GetDisplayText()}{text}";
        Console.WriteLine(scripture);

        return scripture;
    }

    public bool IsCompletelyHidden()
    {
        bool isCompletelyHidden = false;

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                isCompletelyHidden = true;
            }
            else
            {
                isCompletelyHidden = false;
                break;
            }
        }

        return isCompletelyHidden;
    }
}