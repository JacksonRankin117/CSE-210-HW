using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        // Creates a loop to check the user input convert it to an int and 
        // append it to a list

        int inputNum = 9; // Initially assigns inputNum a non-zero value. This 
                          // could really be any number, so long as its not 
                          // zero, or the while loop wouldn't go

        while (inputNum != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            inputNum = int.Parse(userResponse);
            
            // Checks if the input is zero. If its not, you add it to the list
            if (inputNum != 0)
            {
                numbers.Add(inputNum);
            }
        }

        // Finds the total value by iterating over every value and adding it to
        // the last
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Finds the average by dividing the sum of the list by the number of 
        // values
        float avg = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {avg}");



        // Goes through each number in the list, and checks if each number is 
        // larger than the last, then returns the largest value
        int maxNum = numbers[0];

        foreach (int i in numbers) {
            if (i > maxNum) {
                maxNum = i;
            }
        }

        Console.WriteLine($"The max is: {maxNum}");
    }
}