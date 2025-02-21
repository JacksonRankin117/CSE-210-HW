using System;

class Assignment
{
    private string _name;
    private string _topic;

    public Assignment(string name, string topic)
    {
        _name = name;
        _topic = topic;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {_name}, Topic: {_topic}");
    }
}