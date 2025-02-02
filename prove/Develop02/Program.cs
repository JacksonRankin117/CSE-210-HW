using System;

class Program
{
    static void Main(string[] args)
    {   
        /*
        // Stores the prompt
        Prompt randPrompt = new Prompt();
        Entry idkman = new Entry();

        // Displays the journal heading and entry to the console
        idkman.Display();
        */

        Journal journal = new Journal();
        journal.Menu();
        
    }
}