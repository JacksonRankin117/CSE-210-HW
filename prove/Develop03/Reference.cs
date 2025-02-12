using System;

class Reference
{
    // Holds all the information for the reference of the scripture
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    // I just looked up how to do this to be completely honest
    public override string ToString()
    {   
        // Makes the reference a string
        return _book + " " + _chapter + ":" + _verse;
    }
}