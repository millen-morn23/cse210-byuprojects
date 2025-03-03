using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int grade = int.Parse(gradePercentage);

        string Letter = "";

        if (grade >= 90)
        {
            Letter ="A";
        }
        else if (grade >= 80)
        {
            Letter="B";
        }
        else if (grade >= 70)
        {
            Letter="C";
        }
        else if (grade >= 60)
        {
            Letter="D";
        }
        else
        {
            Letter="F";
        }

        Console.WriteLine($"Your grade is {Letter}");

        if (grade >= 60)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You failed,But Dont Give Up!");
        }
    }
}