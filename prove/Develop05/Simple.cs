class Simple : Goal 
{
    // Private field to track if the goal is completed
    private bool _isCompleted = false;

    // Default constructor
    public Simple() {}

    // Constructor to initialize from saved data
    public Simple(string[] data)
    {
        _title = data[1];                      // Goal title
        _desc = data[2];                       // Goal description
        _points = int.Parse(data[3]);          // Points awarded for completion
        _isCompleted = bool.Parse(data[4]);    // Whether the goal is already completed
    }

    // Method to get user input for goal details
    public override void GetDescription() 
    {
        Console.Write("Title: ");
        _title = Console.ReadLine();  // Read title from user input

        Console.Write("Description: ");
        _desc = Console.ReadLine();  // Read description from user input

        Console.Write("Points: ");
        if (!int.TryParse(Console.ReadLine(), out _points) || _points < 0)
        {
            Console.WriteLine("Invalid input. Points must be a positive number.");
            _points = 0;  // Default to 0 if the input is invalid
        }
    }

    // Method to calculate points for completing the goal
    public override int CalcPoints() 
    {
        return _isCompleted ? 0 : _points;  // Return points only if the goal is not yet completed
    }

    // Method to mark the goal as completed
    public override void MarkDone() 
    { 
        if (!_isCompleted) // Check if the goal is already completed
        {
            _isCompleted = true; // Mark as completed
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    // Method to save the goal in a formatted string
    public override string Save() 
    { 
        return $"Simple|{_title}|{_desc}|{_points}|{_isCompleted}"; 
    }

    // Method to display the goal details
    public override string Display() 
    {
        return $"[Simple] {_title} - {(_isCompleted ? "Completed" : "Not Done")}";
    }
}
