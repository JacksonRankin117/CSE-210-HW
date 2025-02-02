using System;

class Entry
{
    // Class Attributes
    private Prompt _prompt = new Prompt();
    private DateTime _dateTime = DateTime.Now;
    private string _entryText;

    public void Display()
    {
        // Get a random prompt
        string prompt = _prompt.GetRandomPrompt();

        // Display prompt and get user input
        Console.WriteLine($"{_dateTime} - {prompt}");
        _entryText = Console.ReadLine();
    }
}