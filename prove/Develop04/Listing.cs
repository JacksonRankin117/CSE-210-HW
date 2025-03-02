using System;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>() 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void BeginListing() 
    {
        // Randomly select a prompt
        Random rand = new Random();
        string selectedPrompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("Prompt: " + selectedPrompt);
        Console.WriteLine("Get ready to start listing...");
        
        // Countdown before the user starts listing
        _timer.DisplayLoadingIcon(5);  // 5 seconds countdown for thinking

        Console.WriteLine("Begin listing now!");
        List<string> userItems = new List<string>();

        // Start the timer to give the user time to list items
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {   
            string userInput = Console.ReadLine();
            userItems.Add(userInput);
            
        }

        // Display how many items the user entered
        Console.WriteLine($"You entered {userItems.Count} items.");
    }
}
