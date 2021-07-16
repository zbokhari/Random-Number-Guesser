using System;

namespace number_guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize number of guess attempts
            int guesses = 0;
            // Initial request for a numerical guess
            Console.WriteLine("Guess what number I am thinking of, between 0 and 100");

            // Generate a random number as the correct answer to guess.
            // This is hidden from the guesser until they are correct.
            var numberToGuess = new Random().Next(101);

            //Initialize variable to allow the while loop to execute
            // Set this to -1 as it falls outside the range of 0 to 100, inclusive
            var guessChecker = -1;

            //As the correct answer (numberToGuess) is between 0-100, inclusive, and guessChecker is initialized to
            //-1, the while loop should run at least once.
            while (guessChecker != numberToGuess)
            {

                // Read user guess of type String
                var guessString = Console.ReadLine();

                // try to convert input to integer
                // if it fails inform user and restart loop

                //int.TryParse will attempt to convert guessString to an integer
                // if guessString was purely numerical, guessChecker will be assigned the value of guessString as an integer
                // i.e "99"--> 99

                // !int.TryParse(...) is equivalent to guessString is not numerical after attempting to parse it as an integer
                if (!int.TryParse(guessString, out guessChecker))
                {
                    // Ask the user to please supply a numerical value.   
                    Console.WriteLine("Please choose a numerical value between 0 and 100");
                    // if guessString is not purely numerical, guessChecker will be set to 0 as !int.TryParse is true
                    // in the unlikely event that our numberToGuess also happens to be 0, we need to reset our guessChecker
                    // to -1 so the while loop is not exited.
                    guessChecker = -1;

                    continue;
                }

                // Since, the TryParse(...) from the last step executes regardless of the guessString value,
                // And since we handled nonnumerical values with a prompt, we must now handle integers that were successfully
                // parsed from guessString and assigned to guessChecker

                //Check if integer is between 0 and 100, inclusive, otherwise prompt the user to reenter a new number
                else if (guessChecker < 0 || guessChecker > 100)
                {
                    Console.WriteLine("Your number must be between 0 and 100");
                    continue;

                }
                // If the user guess number is less than the correct answer, prompt them to guess higher.
                else if (guessChecker < numberToGuess)
                {
                    Console.WriteLine("Try a higher number");
                    // Add 1 guess to the guess attempt counter
                    guesses++;
                    continue;

                }
                // If the user guess number is more than the correct answer, prompt them to guess lower.
                else if (guessChecker > numberToGuess)
                {
                    Console.WriteLine("Try a lower number");
                    // Add 1 guess to the guess attempt counter
                    guesses++;
                    continue;

                }
            }
            // If the user guess is the correct answer, congratulate the user, add one to the guess counter.
            // Inform them how many total guesses it took to arrive at the correct answer.
            guesses++;
            Console.WriteLine($"Congrats. You guessed right in {guesses} guess(es). The number is {numberToGuess}.");

        }
    }
}