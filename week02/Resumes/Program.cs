class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        const string fileName = "journal.txt";
        bool isRunning = true;

        // Extra feature: the program reports how many entries are saved or loaded.
        while (isRunning)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine() ?? "";
                    journal.AddEntry(new Entry(prompt, response));
                    Console.WriteLine("Entry added.");
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile(fileName);
                    Console.WriteLine($"Saved {journal.EntryCount} entries to {fileName}.");
                    break;
                case "4":
                    journal.LoadFromFile(fileName);
                    Console.WriteLine($"Loaded {journal.EntryCount} entries from {fileName}.");
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}