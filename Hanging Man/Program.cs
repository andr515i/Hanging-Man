using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman_Man
{
    class Program
    {

        // hangman game

        static void Main(string[] args)
        {
            bool run = true;  // for the while loop, so we can get out when we geuss the word
            bool wrongGuess = false;
            int livesSpent = 0;


            Console.WriteLine("Welcome to Hangman! only enter 1 letter, this includes spaces and special characters");
            string[] listwords = new string[10];  // the list with words, just an example, could have loaded words from a file and done it through that instead.
            listwords[0] = "sheep";
            listwords[1] = "goat";
            listwords[2] = "computer";
            listwords[3] = "america";
            listwords[4] = "watermelon";
            listwords[5] = "icecream";
            listwords[6] = "jasmine";
            listwords[7] = "pineapple";
            listwords[8] = "orange";
            listwords[9] = "mango";

            Random random = new Random();
            var randomWord = random.Next(0, 9);  // pseudo random word to be chosen for the game
            string mysteryWord = listwords[randomWord];
            char[] guess = new char[mysteryWord.Length]; // char array that holds all the correct guesses and the length of the word
            Console.Write("Please enter your guess: ");

            for (int p = 0; p < mysteryWord.Length; p++) // populate the guess-char array with placeholders 
            {
                guess[p] = '*';
            }

            while (run)  // main loop
            {
                wrongGuess = true; // true on default
                char playerGuess = char.Parse(Console.ReadLine());  // parse the input to 
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j]) // for correct guess in chosen word, populate correct guess into guess array
                    {
                        wrongGuess = false;  // make sure to make it false so that we dont eat lives away for no reason
                        guess[j] = playerGuess;
                        string guessString = new string(guess);
                        if (guessString == mysteryWord)
                        {
                            run = false;
                            Console.WriteLine("you win, the word was: " + mysteryWord);
                        }
                    }
                }
                Console.WriteLine(guess);
                if (wrongGuess)  // if you input a wrong guess
                { 
                    livesSpent++;  // die at 7 lives!
                }
                // ascii art ripped straight from a github 
                if (livesSpent == 1) {
                    Console.WriteLine(@"
  +---+
  |   |
      |
      |
      |
      |
========="); 
                }
                if (livesSpent == 2)
                {
                    Console.WriteLine(@"
  +---+
  |   |
  O   |
      |
      |
      |
=========");
                }
                if (livesSpent == 3) { Console.WriteLine(@"
  +---+
  |   |
  O   |
  |   |
      |
      |
========="); }
                if (livesSpent == 4) { Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
========="); }
                if (livesSpent == 5) { Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
========="); }
                if (livesSpent == 6) { Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
========="); }
                if (livesSpent == 7) {
                    Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========");
                    Console.WriteLine("you killed the hanging man! how could you?!?!??");
                    run = false;
                    Console.WriteLine("the word was: " + mysteryWord);
                        
                        }
            }
        }
    }
}
