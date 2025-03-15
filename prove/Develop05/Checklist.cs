class Checklist : Goal 
{   
    // Tracks how many times the goal has been attempted
    private int _attempts;

    // Bonus points awarded when the required attempts are completed
    private int _bonus;

    // Number of attempts required to complete the goal
    private int _required_attempts;

    // Default constructor
    public Checklist() { }

    // Constructor to initialize from saved data
    public Checklist(string[] data)
    {   
        // Assigns values from the saved file to the respective variables
        _title = data[1];                           // Goal title
        _desc = data[2];                            // Goal description
        _points = int.Parse(data[3]);               // Points per attempt
        _bonus = int.Parse(data[4]);                // Bonus points for full completion
        _attempts = int.Parse(data[5]);             // Attempts made so far
        _required_attempts = int.Parse(data[6]);    // Total attempts required for full completion
    }

    // Method to get user input for goal details
    public override void GetDescription() 
    {   
        // Prompt the user to enter goal details
        Console.Write("Title: "); 
        _title = Console.ReadLine();

        Console.Write("Description: "); 
        _desc = Console.ReadLine();

        Console.Write("Points per attempt: "); 
        if (!int.TryParse(Console.ReadLine(), out _points) || _points < 0)
        {
            Console.WriteLine("Invalid input. Points must be a positive number.");
            _points = 0; // Default to 0 if the input is invalid
        }

        Console.Write("Bonus for completion: "); 
        if (!int.TryParse(Console.ReadLine(), out _bonus) || _bonus < 0)
        {
            Console.WriteLine("Invalid input. Bonus must be a positive number.");
            _bonus = 0; // Default to 0 if the input is invalid
        }

        Console.Write("Attempts required for completion: "); 
        if (!int.TryParse(Console.ReadLine(), out _required_attempts) || _required_attempts <= 0)
        {
            Console.WriteLine("Invalid input. Attempts required must be a positive number.");
            _required_attempts = 1; // Default to 1 if the input is invalid
        }
    }

    // Method to calculate points based on completion progress
    public override int CalcPoints() 
    { 
        if (_attempts >= _required_attempts) 
        {
            return _points + _bonus; 
        }
        else 
        {
            return _points;
        }
    }

    // Method to mark an attempt as completed
    public override void MarkDone() 
    { 
        _attempts++; // Increment attempt count
    }

    // Method to save the goal in a formatted string
    public override string Save() 
    { 
        return $"Checklist|{_title}|{_desc}|{_points}|{_bonus}|{_attempts}|{_required_attempts}"; 
    }

    // Method to display the goal details, showing current progress
    public override string Display() 
    { 
        return $"[Checklist] {_title} ({_attempts}/{_required_attempts} done)"; 
    }
}
