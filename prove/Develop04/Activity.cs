using System;

class Activity
{
    public int _duration;
   public Timer _timer = new Timer();

    public void GetDuration()
    {
        Console.Write("Please enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void ShowEndingMessage()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You completed this activity for {_duration} seconds.");

        Console.WriteLine("Press any key to continue to the menu");
        Console.ReadKey();

    }
}
