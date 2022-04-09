
using System.Linq;
using System.Text;

bool theLoopGuard = false;

Random random = new Random();

while (theLoopGuard == false)
{

    // Choose amount of players.
    Console.WriteLine("Choose amount of players from 2 - 4");
    int.TryParse(Console.ReadLine(), out int result);

    // Create array of "players"
    char[] thePlayerMarks = new char[] { };


        if (result < 2 || result < 4)
        {
            Console.WriteLine("Choose players from 2 - 4");
        }

        else if (result == 2)
        {
            thePlayerMarks = new char[] { '1', '2' };

        }

        else if (result == 3)
        {
            thePlayerMarks = new char[] { '1', '2', '3' };

        }

        else if (result == 4)
        {
            thePlayerMarks = new char[] { '1', '2', '3', '4' };

        }


 


    // Store the random writer into variable.

    var theChosePlayerFromArray = random.Next(thePlayerMarks.Length);

    // Let the writer figure the name.
    // Announce the player and let him choose the word.

    Console.WriteLine($"Player {theChosePlayerFromArray} is the writer");
    Console.WriteLine("Please choose a word (8 letters max).");

    string? theWord = Console.ReadLine();

    if (string.IsNullOrEmpty(theWord))
    {
        Console.WriteLine("Please write a word with at least 3 letters.");
    }

    var theWordInUpperCase = theWord.ToUpper();


    // Create a string for letters?

    StringBuilder wordToGuessDashed = new StringBuilder();

    for (int i = 0; i < theWordInUpperCase.Length; i++) // For each letter add a dash to words guessed.
    {
        wordToGuessDashed.Append('-');
    }


    bool gameGuard = false;

    int triesToGuess = 5;

    string usedLetters = String.Empty;

    while(gameGuard == false)
    {

        // Letter guess prompt.
        Console.WriteLine("\nGuess a letter?");

        // Take input from user and change it to uppercase.
        var theGuess = Console.ReadLine().ToUpper();

        char guessAsChar = theGuess[0];



        // Check that input is a single character.

        if (!Char.IsLetter(guessAsChar))
        {
            Console.WriteLine($"{guessAsChar} is not a letter!");
            continue;
        }

        // If the letter is found in the usedletters string then give this.

        if (usedLetters.Contains(guessAsChar))
        {
            Console.WriteLine($"You've already used {guessAsChar}!");
            continue;
        }


        // Alternative winning logic.

        if (theWordInUpperCase.Contains(guessAsChar))
        {
            for (int i = 0; i < theWordInUpperCase.Length; i++)
            {
                if (theWordInUpperCase[i] == guessAsChar) // This loops trough the word and if there is character -
                    // - Add the current character to dashed words.
                {
                    wordToGuessDashed[i] = guessAsChar; 
                }
            }
            Console.WriteLine(wordToGuessDashed.ToString());
        }
        else
        {
            triesToGuess--;
            usedLetters += guessAsChar;
            Console.WriteLine(wordToGuessDashed.ToString());
            if (triesToGuess < 5)
            {
                Console.WriteLine($"Used letters: {usedLetters}");
            }
        }

        // Winning condition.
        if (wordToGuessDashed.ToString().Equals(theWordInUpperCase))
        {
            gameGuard = true;

            Console.WriteLine("Starting new game!");
        }


        if (triesToGuess == 0)
        {
            Console.WriteLine("All tries done.");
            gameGuard = true;
        }
       
    }


}





