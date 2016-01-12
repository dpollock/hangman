# Hangman Crash Course

Drawing the hangman - 
```c#
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
```
