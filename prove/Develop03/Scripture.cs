using System;

class Scripture
{   
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {   
        // This assigns a reference object to the _reference field
        _reference = reference;

        // Splits the given text into words, converts each word into a Word 
        // object, and stores them in a list.
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        // Displays the scripture reference using the overridden ToString() method
        Console.Write(_reference.ToString() + " - ");

        // Iterates through the list of words in the scripture
        foreach (Word word in _words)
        {   
            // Adds a space between each Word object, and writes each object to
            // the console
            Console.Write(word.Display() + " ");
        }
        // This line just adds a space between the scripture line and the next
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {   
        // Appends the words that aren't hidden to a list
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // Checks the number of words to hide by taking an arguemnt from the 
        // user, and the number of visible words left
        int wordsToHide = Math.Min(count, visibleWords.Count);
        
        // Iterates through the list of words to hide
        for (int i = 0; i < wordsToHide; i++)
        {   
            // Grabs the indes of the next visible word
            int index = _random.Next(visibleWords.Count);

            // Hides the word at the index
            visibleWords[index].Hide();

            // Removes the hidden word at the index of the list of visible 
            // words
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {   
        // Checks if all the words in the scripture are hidden
        return _words.All(w => w.IsHidden());
    }
}
    