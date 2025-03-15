class Eternal : Goal 
{
    // Default constructor
    public Eternal() { }

    // Constructor to initialize from saved data
    public Eternal(string[] data) 
    { 
        _title = data[1];     // Goal title
        _desc = data[2];      // Goal description
        _points = int.Parse(data[3]); // Points awarded per completion
    }

    // Method to get user input for goal details
    public override void GetDescription() 
    {
        Console.Write("Title: "); 
        _title = Console.ReadLine();

        Console.Write("Description: "); 
        _desc = Console.ReadLine();

        Console.Write("Points per completion: "); 
        if (!int.TryParse(Console.ReadLine(), out _points) || _points < 0)
        {
            Console.WriteLine("Invalid input. Points must be a positive number.");
            _points = 0; // Default to 0 if the input is invalid
        }
    }

    // Method to calculate points (Eternal goals always give the same points)
    public override int CalcPoints() 
    { 
        return _points; 
    }

    // Method to mark the goal as done (not applicable for Eternal goals)
    public override void MarkDone() 
    { 
        // Eternal goals are never "completed"; they can be repeated indefinitely
    }

    // Method to save the goal in a formatted string
    public override string Save() 
    { 
        return $"Eternal|{_title}|{_desc}|{_points}"; 
    }

    // Method to display the goal details
    public override string Display() 
    { 
        return $"[Eternal] {_title}"; 
    }
}
