using System;

class Reference
{
    private string book;
    private int chapter;
    private int verse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public override string ToString()
    {
        return book + " " + chapter + ":" + verse;
    }
}