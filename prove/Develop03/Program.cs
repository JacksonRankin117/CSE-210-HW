using System;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input == "quit")
                break;
            
            scripture.HideRandomWords(3);
        }
        
        if (scripture.AllWordsHidden()) {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nAll words are hidden. Thanks for memorizing this scripture!");
        }
    }
}