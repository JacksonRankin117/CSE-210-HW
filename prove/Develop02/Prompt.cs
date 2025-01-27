using System;

public class Prompt 
{
    public void randomPrompt()
    {
        int rnd = new Random().Next(1, 6);

        switch (rnd)
        {
            case 1:
                Console.WriteLine("Prompt1");
                break;
            case 2:
                Console.WriteLine("Prompt2");
                break;
            case 3:
                Console.WriteLine("Prompt3");
                break;
            case 4:
                Console.WriteLine("Prompt4");
                break;
            case 5:
                Console.WriteLine("Prompt5");
                break;
        }
    }
}
