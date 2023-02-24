namespace MathGame;

internal class MathGameEngine
{
    private List<Game> gameHistory = new();

    internal void PlayGame(GameType gameType, GameDifficulty gameDifficulty, int numberOfQuestions = 5)
    {
        Game game = new Game { Type = gameType, Difficulty = gameDifficulty, NumberOfQuestions = numberOfQuestions };
        Random random = new Random();
        int score = 0;
        char operation = GetOperatorSymbol(gameType);

        for (int i = 0; i < numberOfQuestions; i++)
        {
            int[] gameNumbers = GetGameNumbers(gameType, gameDifficulty, random); 
            int number1 = gameNumbers[0];
            int number2 = gameNumbers[1];
            int correctAnswer = gameNumbers[2];

            Console.Clear();
            Console.WriteLine($"{gameType} Game");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Question {i + 1} out of {numberOfQuestions}:");
            Console.WriteLine($"What is {number1} {operation} {number2}?");
            Console.Write("The answer is: ");
            int userAnswer = Helpers.ValidateInputIsInteger(input: Console.ReadLine(), queryMessage: "The answer is: ");

            if (userAnswer == correctAnswer)
            {
                score++;
                Console.Write("You got the correct answer. Well done! ");
            }
            else
            {
                Console.Write("You got the wrong answer. Better luck next time! ");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        game.EndTime = DateTime.UtcNow;
        game.Score = score;
        SaveGame(game);

        Console.WriteLine($"\nGame over. Your final score is {score} out of {numberOfQuestions}. Press any key to go back to the main menu...");
    }

    private static int[] GetGameNumbers(GameType gameType, GameDifficulty gameDifficulty, Random random)
    {
        int minValue, MaxValue;
        int number1, number2, correctAnswer;

        switch (gameDifficulty)
        {
            case GameDifficulty.Easy:
                minValue = 0;
                MaxValue = 50;
                break;
            case GameDifficulty.Normal:
                minValue = 25;
                MaxValue = 75;
                break;
            case GameDifficulty.Hard:
                minValue = 50;
                MaxValue = 100;
                break;
            default: throw new Exception($"Invalid game difficulty '{gameType}'");
        }

        switch (gameType)
        {
            case GameType.Addition:
                number1 = random.Next(minValue, MaxValue);
                number2 = random.Next(minValue, MaxValue);
                correctAnswer = number1 + number2;
                break;
            case GameType.Subtraction:
                number1 = random.Next(minValue, MaxValue);
                number2 = random.Next(minValue, MaxValue);
                correctAnswer = number1 - number2;
                break;
            case GameType.Multiplication:
                if (minValue != 0)
                {
                    minValue /= 5;
                }
                number1 = random.Next(minValue, MaxValue / 5);
                number2 = random.Next(minValue, MaxValue / 5);
                correctAnswer = number1 * number2;
                break;
            case GameType.Division:
                do
                {
                    number1 = random.Next(minValue, MaxValue);
                    number2 = random.Next(minValue + 1, MaxValue);
                } while (number1 % number2 != 0);
                correctAnswer = number1 / number2;
                break;
            default: throw new Exception($"Invalid game type '{gameType}'");
        }

        return new int[] { number1, number2, correctAnswer };
    }

    private static char GetOperatorSymbol(GameType gameType)
    {
        char operation = 'e';
        if (gameType == GameType.Addition)
        {
            operation = '+';
        }
        else if (gameType == GameType.Subtraction)
        {
            operation = '-';
        }
        else if (gameType == GameType.Multiplication)
        {
            operation = '*';
        }
        else if (gameType == GameType.Division)
        {
            operation = '/';
        }

        return operation;
    }

    private void SaveGame(Game game)
    {
        this.gameHistory.Add(game);
    }

    internal void PrintGameHistory()
    {
        Console.Clear();
        Console.WriteLine("Game history:");
        if (this.gameHistory.Count > 0)
        {
            foreach (var game in this.gameHistory)
            {
                Console.WriteLine(game);
            }
        }
        else
        {
            Console.WriteLine("No game history to show, go play some games :)");
        }
        Console.WriteLine("Press any key to go back to the main menu...");
    }

    internal int GetNumberOfQuestions()
    {
        Console.Write("Enter the number of questions you want: ");
        int numberOfQuestions = Helpers.ValidateInputIsPositiveInteger(input: Console.ReadLine(), queryMessage: "Number of questions: ");

        return numberOfQuestions;
    }

    internal GameDifficulty GetDifficulty()
    {
        bool isValidDifficulty = false;
        GameDifficulty difficulty = GameDifficulty.Easy;
        do
        {
            Console.WriteLine("\n1 - Easy");
            Console.WriteLine("2 - Normal");
            Console.WriteLine("3 - Hard");
            Console.Write("Enter the difficulty level: ");
            var choice = Helpers.ValidateInputIsInteger(input: Console.ReadLine(), queryMessage: "Difficulty: ");

            switch (choice)
            {
                case 1:
                    difficulty = GameDifficulty.Easy;
                    isValidDifficulty = true;
                    break;
                case 2:
                    difficulty = GameDifficulty.Normal;
                    isValidDifficulty = true;
                    break;
                case 3:
                    difficulty = GameDifficulty.Hard;
                    isValidDifficulty = true;
                    break;
                default:
                    Console.WriteLine($"Your choice of '{choice}' is not a valid choice, press any key to try again...");
                    Console.ReadLine();
                    break;
            }
        } while (!isValidDifficulty);

        return difficulty;
    }
}
