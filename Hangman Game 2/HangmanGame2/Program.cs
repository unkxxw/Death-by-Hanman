
using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

// List of words that can be used for the game.
var words = new[]
{
    "goat",
    "error",
    "computer",
    "code",
    "commendation",
    "run",
    "please",
    "debug",
};

// One random word is picked from the array
var chosenWord = words[new Random().Next(0, words.Length - 1)];

// Valid characters (single character between a and z).
var validCharacters = new Regex("^[a-z]$");

//Number of gusses to be made
var guesses = 10;

//An empty array that will contain all the letters entered by the player
var letters = new List<string>();


Console.WriteLine("Welcome to Hangman 2");

gameStart:
//Looping through all the guesses
while (guesses != 0)
{

    //keeping count of all the guesses made
    var chractersLeft = 0;

    //looping through all the characters of the word
    foreach (var character in chosenWord)
    {
        //Converting the letter to a string
        var letter = character.ToString();

        //testing weather the letter entered is in the array
        if (letters.Contains(letter))
        {
            Console.Write(letter);
        }
        else
        {
            Console.Write("_ ");

            //increaseing the count of letters left to determine if the game is finished or not
            chractersLeft++;
        }
    }
    Console.WriteLine(string.Empty);

    // If there are no characters left, the game is over the  loops breaks out
    if (chractersLeft == 0)
    {
        break;
    }

    Console.WriteLine("Type in a letter: ");

    //Converting the string to lowercase
    var key = Console.ReadKey().Key.ToString().ToLower();
    Console.WriteLine(string.Empty);

    //testing if the character entered is vaild
    if (!validCharacters.IsMatch(key))
    {
        //if the character entered is not vaild the loop resets
        Console.WriteLine($"The letter {key} is not vaild. So try agian.");
        continue;
    }

    //testing if the letter has been used 
    if (letters.Contains(key))
    {
        Console.WriteLine("*sigh* you do realize you've used this letter before");
        continue;
    }
    //adding the letter to the array of letters used since it has not been used yet
    letters.Add(key);

    //if the letter guessed is not in the chosen word then the number of guesses is reduced
    if (!chosenWord.Contains(key))
    {
        guesses--;
        //if the amount of guesses reaches 0 the the game ends
        if (guesses > 0)
        {
            Console.WriteLine($"The letter {key} is not in the word. By the way you have {guesses} {(guesses == 1 ? "try" : "tries")} left");
        }
    }
}
//if the player has guessed the right word we print the win messeage and the amount of guesses left
if (guesses > 0)
{
    Console.WriteLine($"By some miricle you won with {guesses} {(guesses == 1 ? "guess" : "guesses")} left!");
    Console.Write("Would you like to play again? (Y/N): ");
    String answer = Console.ReadLine().ToUpper();
    if (answer == "Y")
        {
            goto gameStart;
        }
    else if (answer == "N")
        {
            return;
        }
       
}
//if the player has used all of thier guesses then we print the lose message and the word they failed to guess
else
{
    Console.WriteLine($"Wow... not only did you loose, you also couldn't guess {chosenWord}");
    Console.WriteLine("\n+---+");
    Console.WriteLine(" O   |");
    Console.WriteLine("/|\\  |");
    Console.WriteLine("/ \\  |");
    Console.WriteLine("    ===");
    Console.Write("Would you like to play again? (Y/N): ");
    String answer = Console.ReadLine().ToUpper();
    if (answer == "Y")
    {
        goto gameStart;
    }
    else if (answer == "N")
    {
        return;
    }
}


//Console.Write("Do you want to play again [Y/N]?");
//String answer = Console.ReadLine().ToUpper();
//if (answer == "Y")
//    continue;
//else if (answer == "N")
//    return;





