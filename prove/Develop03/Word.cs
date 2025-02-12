using System;

class Word
{
    private string original;
    private bool isHidden;

    public Word(string text)
    {
        // Initializes each word as the original word and visible
        original = text;
        isHidden = false;
    }

    public void Hide()
    {   
        // Changes the status of the word to invisible
        isHidden = true;
    }

    public bool IsHidden()
    {   
        // Returns the status of the Word
        return isHidden;
    }

    public string Display()
    {
        // I'm gonna be honest, I looked up how to do this
        // This part returns a bunch of '_' with the same length as the 
        // original word
        string masked = new string('_', original.Length);
        return isHidden ? masked : original;
    }
}