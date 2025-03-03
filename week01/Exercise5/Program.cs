using System;
using System.ComponentModel.DataAnnotations;

partial class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = GetUserName();
        int userNumber = GetNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);

    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Program!");

    }

    static string GetUserName()
    {
        Console.Write("What is your name? ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int GetNumber()
    {
        Console.Write("Enter a number: ");
        string userResponse = Console.ReadLine();
        int userNumber = int.Parse(userResponse);

        return userNumber;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"Hello, {userName}! Your number squared is {squaredNumber}");
    }
}