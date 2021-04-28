using System;
using System.Threading;

namespace DiceRoll
{
    class Program
    {
        public int lives = 0;
        public long score = 0;
        public int countToNextLife = 0;

        public int rollOne = 0;
        public int rollTwo = 0;

        public bool playGame = true;
        public bool runGame = true;

        private bool playRounds()
        {
            while (playGame) {
                rollOne = new Random().Next(6);
                rollTwo = new Random().Next(6);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You rolled a " + rollOne + " and a " + rollTwo);

                if (rollOne == rollTwo)
                {
                    if (lives > 0)
                    {
                        lives = lives - 1;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Your dice were the same, but you had a life to spare! You now have " + lives + " lives");
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Both your dice were the same! You lost!");
                        playGame = false;
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    score = score + rollOne + rollTwo;
                    countToNextLife = countToNextLife + rollOne + rollTwo;
                    Console.WriteLine("Your score is now " + score);

                    if (countToNextLife >= 50)
                    {
                        countToNextLife = 0;
                        lives = lives + 1;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You gained 50 points! You have gained a life! You now have " + lives + " lives!");
                    }
                }
                Console.Title = "DiceRoll! Lives: " + lives + " Score: " + score;
                Thread.Sleep(100);
            }

            bool continueGame = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Play again? (Y/N): ");
            String option = Console.ReadLine();
            if (option.ToLower() == "y")
            {
                continueGame = true;
            } else
            {
                Console.WriteLine("Thanks for playing!");
            }
            return continueGame;
        }

        private void resetGameParams()
        {
            score = 0;
            lives = 0;
            playGame = true;
            rollOne = 0;
            rollTwo = 0;
            countToNextLife = 0;
        }

        private void showTitleGraphic()
        {
            Console.WriteLine(
            " _____  _          _____       _ _ \r\n" +
            "|  __ \\(_)        |  __ \\     | | |\r\n" +
            "| |  | |_  ___ ___| |__) |___ | | |\r\n" +
            "| |  | | |/ __/ _ \\  _  // _ \\| | |\r\n" +
            "| |__| | | (_|  __/ | \\ \\ (_) | | |\r\n" +
            "|_____/|_|\\___\\___|_|  \\_\\___/|_|_|\r\n"
            );
        }


        private void startScreen()
        {
            while (runGame)
            {
                Console.Title = "DiceRoll!";
                resetGameParams();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                showTitleGraphic();
                Console.WriteLine("Welcome to DiceRoll!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Press enter to start the game! ");
                Console.ReadLine();
                runGame = playRounds();
            }
        }

        static void Main(string[] args)
        {
            new Program().startScreen();
        }
    }
}
