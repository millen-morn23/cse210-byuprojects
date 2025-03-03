using System;
using System.Collections.Generic;

partial class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        //do while loop to get the numbers from the user
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            //add the number to the list
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        
        //calculate the sum of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }   

        Console.WriteLine($"The sum of the numbers is {sum}");

        // Part 2: Calculate the average  
        // To avoid integer division, we convert the sum to a float before performing the division.  
        // If both sum and count remain integers, the division would round down to the nearest whole number,  
        // even if the result is stored in a float variable.  

        // By casting one of the values to a float, the operation is treated as floating-point division,  
        // ensuring we get an accurate decimal result. 
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average of the numbers is {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                //if the greater number is found, assign it to the max variable
                max = number;
            }

            }         
            Console.WriteLine($"The maximum number is {max}");


        // Stretch Requirement 1: Find the smallest positive number
        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        if (smallestPositive.HasValue)
        {
            Console.WriteLine($"The smallest positive number is {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        // Stretch Requirement 2: Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        }    

         
}