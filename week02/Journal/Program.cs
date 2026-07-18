using System;

class Program
{
    static void Main(string[] args)
    {
        // To exceed the core requirements, the journal is saved and loaded as a real
        // CSV file instead of a simple separator-based text file. Entry.ToCsvLine()
        // wraps any field containing a comma, quote, or newline in quotes (doubling
        // internal quotes), and Entry.FromCsvLine() parses those quoted fields back
        // correctly. This means the saved file can be opened directly in Excel or
        // Google Sheets without breaking, even if a response contains commas.

        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry(prompt, response);
                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Please select a valid choice.");
            }
        }
    }
}