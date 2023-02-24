namespace MathGame;

internal class Menu
{
    internal void DisplayMenu(string name)
    {
        MathGameEngine mathGameEngine = new();
        bool isPlayingGame = true;

        Console.Clear();
        Console.WriteLine($"Welcome {name}, to the Math Game. We hope you enjoy the game.");
        Console.WriteLine("Press any button to continue to the game menu...");
        Console.ReadLine();

        do
        {
            Console.Clear();
            Console.WriteLine($"{name}, What would you like to do?");
            Console.WriteLine("------------------------------");
            Console.WriteLine("V - View game history");
            Console.WriteLine("A - Play Addition game");
            Console.WriteLine("S - Play Subtraction game");
            Console.WriteLine("M - Play Multiplication game");
            Console.WriteLine("D - Play Division game");
            Console.WriteLine("Q - Quit the game");
            Console.WriteLine("------------------------------");
            Console.Write("I want to: ");

            var choice = Console.ReadLine();
            int numberOfQuestions;
            GameDifficulty gameDifficulty;

            switch (choice.Trim().ToLower())
            {
                case "v":
                    mathGameEngine.PrintGameHistory();
                    break;
                case "a":
                    numberOfQuestions = mathGameEngine.GetNumberOfQuestions();
                    gameDifficulty = mathGameEngine.GetDifficulty();
                    mathGameEngine.PlayGame(GameType.Addition, gameDifficulty, numberOfQuestions);
                    //mathGameEngine.PlayAdditionGame();
                    break;
                case "s":
                    numberOfQuestions = mathGameEngine.GetNumberOfQuestions();
                    gameDifficulty = mathGameEngine.GetDifficulty();
                    mathGameEngine.PlayGame(GameType.Subtraction, gameDifficulty, numberOfQuestions);
                    //mathGameEngine.PlaySubstractionGame();
                    break;
                case "m":
                    numberOfQuestions = mathGameEngine.GetNumberOfQuestions();
                    gameDifficulty = mathGameEngine.GetDifficulty();
                    mathGameEngine.PlayGame(GameType.Multiplication, gameDifficulty, numberOfQuestions);
                    //mathGameEngine.PlayMultiplicationGame();
                    break;
                case "d":
                    numberOfQuestions = mathGameEngine.GetNumberOfQuestions();
                    gameDifficulty = mathGameEngine.GetDifficulty();
                    mathGameEngine.PlayGame(GameType.Division, gameDifficulty, numberOfQuestions);
                    //mathGameEngine.PlayDivisionGame();
                    break;
                case "q":
                    Console.WriteLine("You chose to quit the game, see you next time! Press any key to exit...");
                    isPlayingGame = false;
                    break;
                default:
                    Console.WriteLine($"Your choice of '{choice}' is not a valid choice, press any key to try again...");
                    break;
            }
            Console.ReadLine();
        } while (isPlayingGame);
    }
}
