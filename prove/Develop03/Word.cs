public class Word(string text)
{
    private readonly string _text = text;
    private bool _isHidden;

    public bool IsHidden()
    {
        return _isHidden;
    }


    public void Hide()
    {
        _isHidden = true;
    }


    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    public string GetText()
    {
        return _text;
    }

}
