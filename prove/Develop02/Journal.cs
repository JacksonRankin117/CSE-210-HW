public class Journal
{
    private List<Entry> entries = new List<Entry>();  // List of Entry objects
    private Prompt _prompt = new Prompt();  // Ensure _prompt is initialized here

    public void Menu()
    {
        Console.WriteLine("\nWelcome to your journal! What would you like to do?");
        int user_input = 0;
        
        do
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("(1) Write a new entry");
            Console.WriteLine("(2) Display the current journal");
            Console.WriteLine("(3) Load a journal");
            Console.WriteLine("(4) Save the entries to a journal");
            Console.WriteLine("(5) Quit");
            Console.WriteLine("-----------------------------------------------------");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out user_input) || user_input < 1 || user_input > 5)
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (user_input)
            {
                case 1:
                    WriteEntry();
                    break;
                case 2:
                    DisplayJournal();
                    break;
                case 3:
                    LoadJournal();
                    break;
                case 4:
                    SaveJournal();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        } while (user_input != 5);
    }

    private void WriteEntry()
    {
        // Capture the current date and time
        string dateTime = DateTime.Now.ToString();

        // Get a random prompt from the Prompt class
        string prompt = _prompt.GetRandomPrompt();

        // Display the prompt to the user
        Console.WriteLine(prompt);

        // Ask user to input the entry text based on the displayed prompt
        string entryText = Console.ReadLine();

        // Create a new Entry object with the dateTime, prompt, and entryText
        Entry newEntry = new Entry(dateTime, prompt, entryText);  // Pass dateTime, prompt, and entryText
        entries.Add(newEntry);  // Add the entry to the list
        Console.WriteLine("Entry added successfully!");
    }


    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.");
        }
        else
        {
            Console.WriteLine("\nYour journal entries:");
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"{entry.GetDateTime()} - {entry.GetPromptText()}");
                Console.WriteLine(entry.GetEntryText());
                Console.WriteLine();  // Blank line between entries
            }
        }
    }

    private void LoadJournal()
    {
        Console.WriteLine("Enter the file name to load the journal from (e.g., 'my_journal.txt'):");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            entries.Clear();  // Clear current entries before loading

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Read timestamp
                        string dateTime = line;

                        // Read prompt
                        string prompt = reader.ReadLine();

                        // Read entry text
                        string entryText = reader.ReadLine();

                        // Skip the blank line separating entries
                        reader.ReadLine();

                        // Create a new Entry object and pass the three required parameters
                        Entry entry = new Entry(dateTime, prompt, entryText);  // Pass dateTime, prompt, and entryText here
                        entries.Add(entry);  // Add the entry to the list
                    }
                }
                Console.WriteLine("Journal loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No saved journal found with that name.");
        }
    }

    private void SaveJournal()
    {
        Console.WriteLine("Enter the file name to save the journal (e.g., 'my_journal.txt'):");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    // Write the date, prompt, and entry text to the file
                    writer.WriteLine(entry.GetDateTime());
                    writer.WriteLine(entry.GetPromptText());
                    writer.WriteLine(entry.GetEntryText());
                    writer.WriteLine(); // Blank line separating entries
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }
}
