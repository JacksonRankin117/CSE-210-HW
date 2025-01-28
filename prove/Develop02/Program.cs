using System;

class Program
{
    static void Main(string[] args)
    {   
        // Stores the prompt
        Prompt randPrompt = new Prompt();

        // Displays the entry to the console
        Entry idkman = new Entry();

        idkman._EntryDateTime = "Mon Jan 27";
        randPrompt.DisplayPrompt(); 
        idkman._EntryText = "I got some cheese";

        idkman.Display();
        
    }
}