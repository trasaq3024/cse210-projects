using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage (0-100).");
        string input = Console.ReadLine();
        int grade = int.Parse(input);


        string letter = "";
        string sign = "";


        // let determine base letter grade

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"your grade is: {letter}");


        // Determine + or - sign (stretch challange)
        int lastDigit = grade % 10;


        if (letter != "F" && letter != "A") // Only add sign for B,C,D
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && grade < 93)
        {
            sign = "-"; // A- is valid only for 90-92
        }


        // Final grade output
        Console.WriteLine($"your letter grade is: {letter}{sign}");

        // pass/fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulation! you pass the class");
        }
        else
        {
            Console.WriteLine("keep trying! you'll do better next time.");
        }


    


    







    }
}