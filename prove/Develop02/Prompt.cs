class Prompt
{
    // List of prompts
    private List<string> _prompts = new List<string>
    {
        "What was one challenge you had today, and how did you overcome it?",
        "If there was something you could change about your day, what would it be?",
        "What are you most grateful about today?",
        "What was the most interesting thing you have learned today?",
        "What was one mistake you made today, and how will you correct it?"
    };

    // Method to get a random prompt
    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }
}