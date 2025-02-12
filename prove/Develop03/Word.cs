using System;

class Word
{
    private string original;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        original = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        // I had to look up how to do this, but this line allows the Word class
        // to progressively replace the words with '_'
        return IsHidden ? new string('_', original.Length) : original;
    }
}
