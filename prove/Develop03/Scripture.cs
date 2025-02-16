class Scripture
{   
    private Reference _reference;
    private List<string> _verses; // Stores multiple verses
    private List<List<Word>> _words; // Stores words for each verse
    private Random _random = new Random();
    private int _startVerse; // Stores the starting verse number

    public Scripture(Reference reference, params string[] texts)
    {   
        _reference = reference;
        _verses = texts.ToList();
        _startVerse = reference.GetStartVerse(); // Retrieve starting verse from Reference class

        // Split each verse into words and store them as lists
        _words = _verses.Select(text => text.Split(' ').Select(word => new Word(word)).ToList()).ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());

        // Iterate over each verse and print with verse numbers
        for (int i = 0; i < _words.Count; i++)
        {
            int verseNumber = _startVerse + i; // Calculate the verse number
            Console.Write($"{verseNumber}. "); // Print verse number before text
            
            foreach (Word word in _words[i])
            {
                Console.Write(word.Display() + " ");
            }
            Console.WriteLine(); // Move to the next line after each verse
        }
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.SelectMany(verse => verse).Where(w => !w.IsHidden()).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(verse => verse.All(w => w.IsHidden()));
    }
}
