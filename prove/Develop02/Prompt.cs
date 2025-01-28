using System;

class Prompt 
{   
    // Class Attributes
    public string _prompt;

    // This method displays a random prompt when called
    public void DisplayPrompt() {  
 
        // Generates a random number from 1-5
        int rnd = new Random().Next(1, 6);

        // Stores a random prompt in _prompt
        switch (rnd)
        {   
            case 1:
                _prompt = "Prompt1";
                break;
            case 2:
                _prompt = "Prompt2";
                break;
            case 3:
                _prompt = "Prompt3";
                break;
            case 4:
                _prompt = "Prompt4";
                break;
            case 5:
                _prompt = "Prompt5";
                break;
        }

    // Writes the prompt to the console
    Console.Write(_prompt);

    }
}
