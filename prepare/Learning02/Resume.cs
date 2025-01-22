using System;

public class Resume
{
    public string _name;

    // Initializes the list, so the program doesn't explode when I run it
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Creates a loop to display all the details of the job on each line
        foreach (Job job in _jobs)
        {
            // This writes it to the console.
            job.Display();
        }
    }
}