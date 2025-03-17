using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Load scriptures from a file
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found. Please check your scriptures.txt file.");
            return;
        }

        // Allow the user to pick a scripture
        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReference().GetDisplayText()}");
        }

        int selectedIndex;
        while (true)
        {
            Console.Write("Enter the number of the scripture: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out selectedIndex) && selectedIndex > 0 && selectedIndex <= scriptures.Count)
            {
                break;
            }
            Console.WriteLine("Invalid selection. Please enter a valid number.");
        }

        Scripture scripture = scriptures[selectedIndex - 1];

        // Ask user how many words to hide per round
        int wordsToHide;
        while (true)
        {
            Console.Write("How many words would you like to hide per round? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out wordsToHide) && wordsToHide > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }

        // Start memorization loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(wordsToHide); // Hide user-selected number of words
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden! Program finished.");
    }

    static List<Scripture> LoadScriptures(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    scriptures.Add(new Scripture(new Reference(parts[0]), parts[1]));
                }
            }
        }

        return scriptures;
    }
}
