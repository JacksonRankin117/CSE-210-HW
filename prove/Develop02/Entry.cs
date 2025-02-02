using System;

class Entry
{
    private Prompt _prompt = new Prompt();  // Create an instance of the Prompt class
    private DateTime _dateTime;
    private string _entryText;
    private string _promptText;

    // Constructor now accepts dateTime, prompt, and entryText
    public Entry(string dateTime, string prompt, string entryText)
    {
        _dateTime = DateTime.Parse(dateTime);  // Ensure the DateTime is parsed from string
        _promptText = prompt;  // Use the provided prompt text
        _entryText = entryText;  // Set the entry text
    }

    // Display method to show the entry and get user input
    public void Display()
    {
        // Display the prompt and allow user to enter their entry text
        Console.WriteLine($"{_dateTime} - Prompt: {_promptText}");
        Console.WriteLine("Please write your entry:");
        _entryText = Console.ReadLine();  // Capture the user’s entry
    }

    // Public setter for the entry text
    public void SetEntryText(string entryText)
    {
        _entryText = entryText;  // Set the entry text to the provided value
    }

    // Getter for the entry text
    public string GetEntryText()
    {
        return _entryText;  // Return the entry text when needed
    }

    // Getter for the prompt text
    public string GetPromptText()
    {
        return _promptText;  // Return the stored prompt text
    }

    // Getter for the timestamp
    public string GetDateTime()
    {
        return _dateTime.ToString();  // Return the timestamp formatted as a string
    }
}
