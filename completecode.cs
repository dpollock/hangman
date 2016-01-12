   internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to Hangman! You get 6 misses before you lose.");

            var correctGuesses = new List<char>();
            var incorrectGuesses = new List<char>();
            var isGameOver = false;

            var wordToGuess = GetRandomWord();
            var displayToPlayer = new StringBuilder(string.Empty.PadRight(wordToGuess.Length, '-'));

            while (!isGameOver)
            {
                DrawHangman(displayToPlayer.ToString(), incorrectGuesses, correctGuesses);

                Console.WriteLine("Please Make a Guess");
                var guess = Console.ReadLine();

                if (wordToGuess.Contains(guess))
                {
                    //Correct Guess!
                    Console.WriteLine("Correct!");
                    correctGuesses.Add(guess[0]);

                    //update the word we show the user to show their guess revealed.
                    for (var i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess[0])
                        {
                            displayToPlayer[i] = wordToGuess[i];
                        }
                    }
                }
                else
                {
                    //Wrong Guess!
                    Console.WriteLine("Incorrect!");
                    incorrectGuesses.Add(guess[0]);
                }

                //check for win/loss
                if (displayToPlayer.ToString() == wordToGuess)
                {
                    isGameOver = true;
                    Console.WriteLine("You won!!!");
                }

                //check for win/loss
                if (incorrectGuesses.Count == 5)
                {
                    isGameOver = true;
                    Console.WriteLine("You Lost!!! The word was " + wordToGuess);
                }
            }


            Console.ReadLine();
        }

        private static void DrawHangman(string displayToPlayer, List<char> incorrectGuesses,
            List<char> correctGuesses)
        {
            Console.Clear();
            Console.Write("Good Guesses: ");
            foreach (var c in correctGuesses)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Console.Write("Bad Guesses: ");
            foreach (var c in incorrectGuesses)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();


            Console.WriteLine("Your word to guess: " + displayToPlayer);

            var wrong = incorrectGuesses.Count;

            Console.WriteLine(@"______   ");
            Console.WriteLine(@"|     |  ");
            if (wrong > 0) Console.WriteLine(@"|     O  ");
            if (wrong > 1) Console.WriteLine(@"|    /|\ ");
            if (wrong > 2) Console.WriteLine(@"|     |  ");
            if (wrong > 3) Console.WriteLine(@"|    / \ ");

            for (var i = 0; i < 5 - wrong; i++)
            {
                Console.WriteLine(@"|        ");
            }

            Console.WriteLine(@"|        ");
            if (wrong > 4) Console.WriteLine(@"|--      --");
            else Console.WriteLine(@"|---------");
            if (wrong > 4) Console.WriteLine(@"  |      |");
        }


        private static string GetRandomWord()
        {
            var words = new[]
            {
                "acre", "recall", "policeman", "memory", "deeply", "firelace", "university"
            };

            //var words = File.ReadAllLines(@"C:\projects\HangmanCrash\HangmanCrash\hangmanwords.txt");

            var r = new Random();
            var position = r.Next(words.Length);

            return words[position];

        }
    }
