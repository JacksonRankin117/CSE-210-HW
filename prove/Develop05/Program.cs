using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main(string[] args)
    {   
        /* Main Menu */
        string choice;
        do {
            Console.Clear();
            Console.WriteLine($"Total Points: {totalPoints}\n");
            Console.WriteLine("Welcome to the Goal Tracker!");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Calculate potential points");
            Console.WriteLine("7. Quit");
            Console.WriteLine("----------------------------");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    CalculatePotentialPoints();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        } while (choice != "7");
    }


    static void CreateGoal()
    {   
        /* Sub-Menu */
        Console.Clear();
        Console.WriteLine("Choose goal type");
        Console.WriteLine("1. Simple ");
        Console.WriteLine("2. Checklist");
        Console.WriteLine("3. Eternal");

        string goalType = Console.ReadLine();
        Goal newGoal = null;
        
        switch (goalType)
        {
            case "1":
                newGoal = new Simple();
                break;
            case "2":
                newGoal = new Checklist();
                break;
            case "3":
                newGoal = new Eternal();
                break;
        }
        
        // Checks if the new goal isn't a null type
        if (newGoal != null)
        {
            newGoal.GetDescription();
            goals.Add(newGoal);
        }
    }

    static void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("Your goals:");

        // If there aren't any goals...
        if (goals.Count == 0)
        {   
            // Display:
            Console.WriteLine("No goals found.");
        }

        else
        {       
            // Go theough each line and display the goals
            for (int i = 0; i < goals.Count; i++)
            {   
                Console.WriteLine($"{i + 1}. {goals[i].Display()}");
            }
        }
        // Display the number of points
        Console.WriteLine($"Total Points: {totalPoints}");
        Console.ReadKey();
    }


    static void SaveGoals()
    {   
        // Get a filename
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        
        // Write the file
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Save());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    static void LoadGoals()
    {   
        // Get the filename to load form the user
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        // If it doesn't exist...
        if (!File.Exists(filename))
        {   
            // Say we didn't find it
            Console.WriteLine("No saved goals found.");
            return;
        }
        
        // But if it does exist, clear the goals from the goal list, and load them with the goals in the file
        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            totalPoints = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Goal goal = Goal.Load(parts);
                if (goal != null)
                {
                    goals.Add(goal);
                    Console.WriteLine($"Loaded goal: {goal.Display()}");  // Debugging line
                }
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }


    static void RecordEvent()
    {   
        // Calls the method to display each goal
        ListGoals();

        // Asks the user which goal he/she has completed
        Console.Write("Enter goal number to mark as done: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        
        // Calculates the points, and if its done, complete the goal
        if (index >= 0 && index < goals.Count)
        {
            totalPoints += goals[index].CalcPoints();
            goals[index].MarkDone();
        }
    }
    
    static void CalculatePotentialPoints()
    {   
        // Reads a filename from the user.
        Console.Write("Enter filename to calculate potential points: ");
        string filename = Console.ReadLine();
        
        // If the file doesn't exist, tell the user we couldn't find it
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        int potentialPoints = 0;

        // Read the file and calculate the potential points
        using (StreamReader reader = new StreamReader(filename))
        {
            reader.ReadLine(); // Skip the first line (totalPoints, which we don't need here)
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string goalType = parts[0]; // First part is the goal type
                
                switch (goalType)
                {
                    case "Simple":
                        // Simple goal: potential points is the fourth value (index 3)
                        potentialPoints += int.Parse(parts[3]);
                        Console.WriteLine(potentialPoints);
                        break;
                            
                    case "Checklist":
                        // Checklist goal: calculate points based on items
                        int pointsPerItem = int.Parse(parts[3]); // Points per checklist item
                        int numberOfItems = int.Parse(parts[6]); // Number of items in the checklist
                        int extraPoints = int.Parse(parts[4]); // Additional points for completing checklist

                        // calculates the number of points
                        potentialPoints += (pointsPerItem * numberOfItems) + extraPoints;
                        break;
                            
                    case "Eternal":
                        // Eternal goals have no potential points, becuase it could be infinite, really
                        break;
                    
                    default:
                        // This is probably unecessary, but if this program doesn't recognise the type of goal, it yells at the user
                        Console.WriteLine($"Unknown goal type: {goalType}");
                        break;
                }
            }
        }

        // Displays the total points to the user, and waits for the user to press a key before going back to the main menu
        Console.WriteLine($"Total Potential Points (excluding Eternal goals): {potentialPoints}");
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }

}
