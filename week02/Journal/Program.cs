using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to CSV");
            Console.WriteLine("4. Load journal from CSV");
            Console.WriteLine("5. Save journal to JSON");
            Console.WriteLine("6. Load journal from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your journal entry: ");
                    string entryText = Console.ReadLine();
                    journal.AddEntry(entryText);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename for CSV: ");
                    string csvFile = Console.ReadLine();
                    journal.SaveToCsv(csvFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load from CSV: ");
                    string loadCsvFile = Console.ReadLine();
                    journal.LoadFromCsv(loadCsvFile);
                    break;
                case "5":
                    Console.Write("Enter filename for JSON: ");
                    string jsonFile = Console.ReadLine();
                    journal.SaveToJson(jsonFile);
                    break;
                case "6":
                    Console.Write("Enter filename to load from JSON: ");
                    string loadJsonFile = Console.ReadLine();
                    journal.LoadFromJson(loadJsonFile);
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid ch1oice, please try again.");
                    break;
            }
        }
    }
}