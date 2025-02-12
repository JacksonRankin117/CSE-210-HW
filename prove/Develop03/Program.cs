using System;

class Program
{
    static void Main()
    {   
        // Holds the scripture information in two class objects
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        
        // Iterates while there are visible words in the list
        while (!scripture.AllWordsHidden())
        {   
            // Clears the console, displays the scripture, and 
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            // Reads what the user wrote
            string input = Console.ReadLine();

            // If the user wrote 'quit', the program quits
            if (input == "quit")
                break;
            
            // Hides however many words you want randomly
            scripture.HideRandomWords(3);
        }
        
        // Checks if all of the words are hidden
        if (scripture.AllWordsHidden()) 
        {
            // Clears the console, and displays the empty scripture
            Console.Clear();
            scripture.Display();

            // Imparts a small goodbye to the user, before closing the program
            Console.WriteLine("\nAll words are hidden. Thanks for memorizing this scripture!");
        }
    }
}