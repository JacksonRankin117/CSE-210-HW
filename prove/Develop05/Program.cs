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
            Console.WriteLine("Welcome to the Goal Tracker!");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Choice: ");
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
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        } while (choice != "6");
    }

    static void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1. Simple 2. Checklist 3. Eternal");
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
        Console.WriteLine("Your goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Display()}");
        }
        Console.WriteLine($"Total Points: {totalPoints}");
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
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
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }
        
        goals.Clear();
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            totalPoints = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Goal goal = Goal.Load(parts);
                if (goal != null) goals.Add(goal);
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
}