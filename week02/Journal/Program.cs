using System;

/*
CREATIVITY NOTE:
This program exceeds the core requirements by:
- Using CSV format with proper escaping of commas and quotes.
- Supporting full save/load of multi-field entries.
- Cleanly abstracted with separate responsibilities for prompt, entry, and journal handling.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to CSV file");
            Console.WriteLine("4. Load journal from CSV file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAllEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save to (e.g. journal.csv): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToCsv(saveFile);
                    Console.WriteLine("Journal saved as CSV.");
                    break;

                case "4":
                    Console.Write("Enter filename to load from (e.g. journal.csv): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromCsv(loadFile);
                    Console.WriteLine("Journal loaded from CSV.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

