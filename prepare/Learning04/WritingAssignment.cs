using System;

class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    public void GetWritingInfo()
    {
        Console.WriteLine($"Title: {_title}\n");
    }
}