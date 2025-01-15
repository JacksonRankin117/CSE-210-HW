using System;

class Program 
{
    static void Main(string[] args) 
    {   
        // Creates a variable to keep track of the number of guesses
        int numGuesses = 1;

        // Asks the user for the magic number and converts it to an integer
        Console.WriteLine("What is the magic number? ");
        string magicNumInput = Console.ReadLine();
        int magicNum = int.Parse(magicNumInput);

        // Asks the user to guess, and converts it to an integer
        Console.WriteLine("What is your guess? ");
        string guessInput = Console.ReadLine();
        int guessNum = int.Parse(guessInput);

        // Creates a while loop to keep the user guessing
        while (guessNum != magicNum) {
            if (guessNum < magicNum) {
                numGuesses ++;
                Console.WriteLine("Too Low! What is your next guess?");
                guessInput = Console.ReadLine();
                guessNum = int.Parse(guessInput);
            }
            else if (guessNum > magicNum) {
                numGuesses ++;
                Console.WriteLine("Too High! What is your next guess?");
                guessInput = Console.ReadLine();
                guessNum = int.Parse(guessInput);
            }
        }

        // Congratulates the user on a job well done.
        Console.Write($"Congratulations! You got the magic number {magicNum} in {numGuesses} tries.");
    }
}