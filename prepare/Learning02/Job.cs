using System;

public class Job
{    
    // Creates various member variables
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Creates a 
    public void Display()
    {   
        // Displays each member variable in the template I want
        Console.WriteLine($"{_jobTitle} for {_company} from {_startYear} to {_endYear}.");
    }
}