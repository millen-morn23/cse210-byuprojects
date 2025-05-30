using System;

class Program
{
    static void Main(string[] args)
    {
        //  base "Assignment" object
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        Console.WriteLine();

        //  MathAssignment object
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "5.3", "8-26");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        Console.WriteLine();

        //  WritingAssignment object
        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
