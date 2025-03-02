using System;

class Program
{
    static void Main()
    {
        // Initialize activity objects
        BreathingActivity _breathe = new BreathingActivity();
        ReflectionActivity _reflect = new ReflectionActivity();
        ListingActivity _list = new ListingActivity();

        // Initializes the string that holds the activity number
        string _activityNum = "";

        do 
        {   
            // Menu
            Console.Clear();
            Console.WriteLine("Welcome to the mindfulness app!");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("What mindfulness activity did you want to do?");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");
            Console.WriteLine("-------------------------------------------------");
            _activityNum = Console.ReadLine();

            // Provides the user with the activity
            switch (_activityNum) 
            {
                case "1":
                    _breathe.GetDuration();
                    _breathe.BeginBreathing();
                    _breathe.ShowEndingMessage();
                    break;
                case "2":
                    _reflect.GetDuration();
                    _reflect.BeginReflecting();
                    _reflect.ShowEndingMessage();
                    break;
                case "3":
                    _list.GetDuration();
                    _list.BeginListing();
                    _list.ShowEndingMessage();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please choose a number between 1 and 4.");
                    break;
            }
        } while (_activityNum != "4");
    }
}
