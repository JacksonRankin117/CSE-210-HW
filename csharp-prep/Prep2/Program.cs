/*
Jackson Rankin
CSE 210
Brother Gibbons
11th January, 2025

This program determines what letter grade a student has earned, and whether or
not they have a passing score
*/

using System;

class Program {
    static void Main(string[] args) {   
        // Ask the user for the grade
        Console.WriteLine("What grade did you get on a scale from 0 to 100?");
        string grade = Console.ReadLine();
        
        // Validate and parse input
        if (int.TryParse(grade, out int gradeValue)) {
            string letterGrade;

            // Determine the letter grade
            if (gradeValue >= 90) {
                letterGrade = "A";
            }
            else if (gradeValue >= 80) {
                letterGrade = "B";
            }
            else if (gradeValue >= 70) {
                letterGrade = "C";
            }
            else if (gradeValue >= 60) {
                letterGrade = "D";
            }
            else {
                letterGrade = "F";
            }

            // Output the result
            if (gradeValue >= 70) {
                Console.WriteLine($"You got a {letterGrade}. You passed!");
            }
            else {
                Console.WriteLine($"You got a {letterGrade}. You failed.");
            }
        } 
        else {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
        }
    }
}
