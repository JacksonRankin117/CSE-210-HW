using System;

class Program
{
    static void Main()
    {   
        // Holds the scripture information in two class objects
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, 
        "Trust in the Lord with all your heart and lean not on your own understanding;", 
        "In all your ways submit to him, and he will make your paths straight.");

        // Iterates while there are visible words in the list
        while (!scripture.AllWordsHidden())
        {   
            // Clears the console, displays the scripture, and displays further instruction
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            // Reads what the user wrote
            string input = Console.ReadLine();

            // If the user wrote 'quit', the program quits
            if (input == "quit")
                break;
            
            // Hides however many words you want randomly
            scripture.HideRandomWords(2);
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