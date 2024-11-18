public class Word
{
    private string _text;
    private string _initText;
    private bool _isHidden;

    public Word(string text)
    {
        _initText = text;
        _text = _initText;
    }


    public void Hide()
    {
        foreach (char letter in _text)
        {
            _text = _text.Replace(letter, '_');
        }        
    }

    public void Show()
    {
        _text = _initText;
    }

    public bool IsHidden()
    {
        if (_text.StartsWith("_"))
        {
            _isHidden = true;
        }
        else
        {
            _isHidden = false;
        }

        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}