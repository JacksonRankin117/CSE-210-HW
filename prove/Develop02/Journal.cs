using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private int user_input = 0;

    public void Menu()
    {
        Console.WriteLine("\nWelcome to your journal! What would you like to do?");
        do
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("(1) Write a new entry");
            Console.WriteLine("(2) Display the current journal");
            Console.WriteLine("(3) Load a journal");
            Console.WriteLine("(4) Save the entries to a journal");
            Console.WriteLine("(5) Quit");
            Console.WriteLine("-----------------------------------------------------");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out user_input) || user_input < 1 || user_input > 5)
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (user_input)
            {
                case 1:
                    // Write entry stuff here
                    break;
                case 2:
                    // Display journal stuff here
                    break;
                case 3:
                    // load journal stuff here
                    break;
                case 4:
                    // Save journal stuff here
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        } while (user_input != 5);
    }
}
