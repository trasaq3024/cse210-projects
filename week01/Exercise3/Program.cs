using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Step 5: Outer loop to replay the game
        while (playAgain.ToLower() == "yes")
        {

            // CORE STEP 1: Get magic number from user (manual entry)
            // Console.Write("What is the magic number? ");
            // int magicNumber = int.Parse(Console.ReadLine());
            
            // CORE STEP 3: Replace with random number from 1 to 100

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // 1–100

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("\nI'm thinking of a number between 1 and 100...");

            // CORE STEP 2: Loop until guess is correct
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out guess))
                {
                    guessCount++;

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            // CORE STEP 4: Report number of guesses
            
            Console.WriteLine($"It took you {guessCount} guesses.");

            // CORE STEP 5: Ask to play again
            
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine(); // Space before restarting
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}   