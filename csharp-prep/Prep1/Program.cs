/*
Jackson Rankin
CSE 210
Brother Gibbons
11th January, 2025

This program asks the user for their first name and surname, then displays the
output text to the terminal

*/

using System;

class Program
{
    static void Main(string[] args)
    {   
        // Asks the user for his or her first name
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        // Asks the user for his or her surname
        Console.WriteLine("What is your surname?");
        string surname = Console.ReadLine();

        // Outputs display text to the terminal, i.e:
        // Your name is Bond, James Bond
        Console.WriteLine($"Your name is {surname}, {firstName} {surname}.");
    }
}
