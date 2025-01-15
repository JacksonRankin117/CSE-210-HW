using System;

class Program 
{
    static void Main(string[] args) 
    {   
        // Creates a variable to keep track of the number of guesses
        int numGuesses = 1;

        // Generates a random number between 1 and 100
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, 101);

        // Asks the user to guess, and converts it to an integer
        Console.WriteLine("Guess a number between 1 and 100");
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

        // Congratulates the user on a job well
        Console.Write($"Congratulations! You got the magic number {magicNum} in {numGuesses} tries.");
    }
}