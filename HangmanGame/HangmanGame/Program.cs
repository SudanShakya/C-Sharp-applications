using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangmanGame
{
    public class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");

            }

            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("     |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/    |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("     ===");
            }
        }

        private static int printWord(List<char>guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach(char c in randomWord)
            {
                if(guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hangman ");
            Console.WriteLine("-----------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "sunflower", "fizzy", "wave", "funny", "lucky", "subway", "joyful", "wishky", "juicy", "stretch", "cobweb", "zodiac", "transplant", "transparent", "cakes", "attract", "beautiful", "abstract", "forecast"};
            int index = random.Next(wordDictionary.Count);  
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimeWrong = 0;

            List<char> currentLettersGuessed = new List<char>();

            int currentLettersRight = 0;
            
            while(amountOfTimeWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\n Letters guessed so far: ");
                foreach(char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }

                //Prompt user for input
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0]; 

                // Check if letter has already been guessed
                if(currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter.");
                    printHangman(amountOfTimeWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Check if letter is in the word 
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if(letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    if (right)
                    {
                        printHangman(amountOfTimeWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountOfTimeWrong++;
                        currentLettersGuessed.Add(letterGuessed);
                        printHangman(amountOfTimeWrong);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord); 
                    }
                }
            }
            Console.WriteLine("\r\nGame is over! Thank you for playing. ;)");
            Console.ReadKey();
        }
    }
}