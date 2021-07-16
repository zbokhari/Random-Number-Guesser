using System;
using System.Linq;

namespace number_guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            int guesses = 0;
            //Initial Request
            Console.WriteLine("Guess what number I am thinking of, between 0 and 100");

            //Generate a random number as the guest
            var numberToGuess = new Random().Next(101);

            //Initialize variable to store the user's guess
            var guessNumber = -1;

            //if guessNumber is not numberToGuess
            while (guessNumber != numberToGuess)
            {

                // read user inout
                var guessString = Console.ReadLine();

                // try to convert input to integer
                // if it fails infor user and restart loop
                if (!int.TryParse(guessString, out guessNumber))
                {
                    Console.WriteLine("Please choose a number between 0 and 100");
                    // If parse fails, guessNumber is set to 0, 
                    // and the program will exit if numbertoGuess
                    // is also 0 so need to reset to 1
                    guessNumber = -1;

                    continue;
                }

                // if the number is out of range, inform user and restart loop
                else if (guessNumber < 0 || guessNumber > 100)
                {
                    Console.WriteLine("Your number must be between 0 and 100");
                    continue;

                }
                // if the number is out of range, inform user and restart loop
                else if (guessNumber < numberToGuess)
                {
                    Console.WriteLine("Try a higher number");
                    guesses++;
                    continue;

                }
                else if (guessNumber > numberToGuess)
                {
                    Console.WriteLine("Try a lower number");
                    guesses++;
                    continue;

                }
            }
            guesses++;
            Console.WriteLine($"Congrats. You guessed right in {guesses} guess(es). The number is {numberToGuess}.");

        }
    }
}