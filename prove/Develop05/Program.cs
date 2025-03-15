using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main(string[] args)
    {
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
                    CalculatePotentialPoints();  // Call the new method to calculate potential points
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
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Display()}");
            }
        }
        Console.WriteLine($"Total Points: {totalPoints}");
        Console.ReadKey();  // Wait for the user to press a key before returning to the menu
    }


    static void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
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
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }
        
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
        ListGoals();
        Console.Write("Enter goal number to mark as done: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        
        if (index >= 0 && index < goals.Count)
        {
            totalPoints += goals[index].CalcPoints();
            goals[index].MarkDone();
        }
    }
    
    static void CalculatePotentialPoints()
    {
        Console.Write("Enter filename to calculate potential points: ");
        string filename = Console.ReadLine();
        
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

                        // Debugging output
                        Console.WriteLine($"Checklist Goal: {pointsPerItem} points/item, {numberOfItems} items, {extraPoints} extra points");

                        // Ensure correct multiplication and addition
                        potentialPoints += (pointsPerItem * numberOfItems) + extraPoints;
                        break;
                            
                    case "Eternal":
                        // Eternal goals have no potential points
                        break;
                    
                    default:
                        Console.WriteLine($"Unknown goal type: {goalType}");
                        break;
                }
            }
        }

        Console.WriteLine($"Total Potential Points (excluding Eternal goals): {potentialPoints}");
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }

}
