using System;

class MathAssignment : Assignment
{
    private int _textbookSection;
    private int _problems;

    public MathAssignment(string name, string topic, int textbookSection, int problems) : base(name, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public void GetHWList()
    {
        Console.WriteLine($"Textbook Section: {_textbookSection}, Problems: {_problems}\n");
    }
}
