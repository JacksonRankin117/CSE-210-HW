using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {   
        // String to hold a choice
        string choice;

        /* Constructs a menu */
        Console.Clear();
        Console.WriteLine("Welcome to the Goal Tracker!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("1. ");
        Console.WriteLine("2. ");
        Console.WriteLine("3. ");
        Console.WriteLine("4. ");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Please choose a menu item:");

        // Reads the users choice
        choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Placeholder for choice 1");
                break;
            case "2":
                Console.WriteLine("Placeholder for choice 2");
                break;
            case "3":
                Console.WriteLine("Placeholder for choice 3");
                break;
            case "4":
                Console.WriteLine("Placeholder for choice 4");
                break;
        }




    }
}