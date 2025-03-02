using System;

class ReflectionActivity : Activity
{   
    private Random _rand = new Random();

    // Stores the list of prompts as a list of strings
    private List<string> _prompts = new List<string>() 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // Stores the list of Qs as a list of strings
    private List<string> _questions = new List<string>() 
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Initialiazes a list of entries
    private List<string> _entries = new List<string>();
    public void BeginReflecting() 
    {   
        Console.WriteLine($"In this activity, you will be given a prompt and a question. The goal of the activity is to reflect and write down as many entries as you can in {_duration} seconds.");
        _timer.DisplayLoadingIcon(5); // Wait five seconds for the user to read the description
        Console.WriteLine("Your prompt is:");

        // Returns a random index number from the prompts list
        int randomPrompt = _rand.Next(0, _prompts.Count);

        // Displays the prompt and allows 5 seconds of thought
        Console.WriteLine(_prompts[randomPrompt]);
        _timer.DisplayLoadingIcon(5);

        // Instructions for the user
        Console.WriteLine("\nYou may begin reflecting on your experiences and write your answers to the questions.");

        // Adds entries to a list while there is time
        DateTime startTime = DateTime.Now;
        do 
        {   
            // Gets a random index number from the questions list
            int randomQ = _rand.Next(0, _questions.Count);

            // Displays the question
            Console.WriteLine(_questions[randomQ]);
            _timer.DisplayLoadingIcon(5);

            // Reads the entry
            string newEntry = Console.ReadLine();

            // Adds the entry to the list
            if (!string.IsNullOrWhiteSpace(newEntry))
            {
                _entries.Add(newEntry);
            }

        } while ((DateTime.Now - startTime).TotalSeconds < _duration);

        // Tells the user how many entries they wrote
        Console.WriteLine($"You wrote {_entries.Count} entries!");
    }
}
