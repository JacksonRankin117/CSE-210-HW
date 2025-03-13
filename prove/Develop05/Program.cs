using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {   
        // Initialize attributes
        string choice;
        string goalType;

        Simple simple = new Simple();
        Checklist checklist = new Checklist();
        Eternal eternal = new Eternal();

        do {
            /* Constructs a menu */
            //Console.Clear();
            Console.WriteLine("Welcome to the Goal Tracker!");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Please choose a menu item:");

            // Reads the users choice
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Console.Clear();
                    Console.WriteLine("What kind of goal would you like to create?");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("1. Simple goal");
                    Console.WriteLine("2. Checklist goal");
                    Console.WriteLine("3. Eternal goal");
                    Console.WriteLine("-------------------------------------------");
                    goalType = Console.ReadLine();

                    switch (goalType)
                    {
                        case "1":
                            simple.GetDescription();
                            break;
                        case "2":
                            checklist.GetDescription();
                            break;
                        case "3":
                            eternal.GetDescription();
                            break;

                    }

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
                case "5":
                    Console.WriteLine("Placeholder for choice 5");
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        } while (choice != "6");
    }
}