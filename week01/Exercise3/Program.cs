using System;

class Program
{
    static void Main(string[] args)
    {
    //    if the user wants to manually enter the the magic number ,use this section:
    //    Console.Write("What is the magic number? ");
    //    int magicNumber = int.Parse(Console.ReadLine());

        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")  // loop the entire game if the user says "yes"
        {
        

    //    Generate a random number between 1 and 100
        Random randomGenarator = new Random();
        int magicNumber = randomGenarator.Next(1, 101);

        int guess = -1;

    //   Keep looping until the user guesses the correct number
        while (guess != magicNumber)
        {
            Console.Write("Guess the magic number: ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high!");
            }
            else
            {
                Console.WriteLine("You guessed the magic number!");
            }
        }
        // Ask the user if they want to play again
        Console.Write("Do you want to play again? (yes/no) ");
        playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thank you for playing!");
    }
    
}