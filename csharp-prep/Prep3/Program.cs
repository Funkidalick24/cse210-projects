using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int guess_number =0;

        
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
                guess_number = guess_number+1;
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
                guess_number = guess_number+1;
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guess_number} guesses. ");
            }

        }                    
    }
}