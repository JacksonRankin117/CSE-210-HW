using System;

class Reflection : Activity
{
    private int _duration;
    private string _title;
    private string _description;

    public Reflection(string title, string description, int duration) : base(title, description, duration)
    {
        _title = title;
        _description = description;
        _duration = duration;
    }

    public void StartReflection()
    {
        Console.WriteLine($"Starting the {_title} activity.");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine("Get ready to reflect.");
    }
}