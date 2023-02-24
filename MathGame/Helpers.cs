namespace MathGame;

internal static class Helpers
{
    internal static string GetName()
    {
        bool IsNameEmpty = true;
        string outputName = "";
        do
        {
            Console.Clear();
            Console.Write("Your name is: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Your name cannot be empty. Press any key to try again...");
                Console.ReadLine();
            }
            else
            {
                outputName = input;
                IsNameEmpty = false;
            }
        } while (IsNameEmpty);

        return outputName;
    }

    internal static int ValidateInputIsInteger(string? input, string queryMessage = "The answer is: ")
    {
        while (!IsInteger(input))
        {
            Console.WriteLine($"Your selection '{input}' must be an integer, try again...\n");
            Console.Write(queryMessage);
            input = Console.ReadLine();
        }

        return int.Parse(input);
    }

    internal static int ValidateInputIsPositiveInteger(string? input, string queryMessage = "The answer is: ")
    {
        while (!IsPositiveInteger(input))
        {
            Console.WriteLine($"Your selection '{input}' must be a positive integer, try again...\n");
            Console.Write(queryMessage);
            input = Console.ReadLine();
        }

        return int.Parse(input);
    }

    private static bool IsInteger(string? input)
    {
        if (int.TryParse(input, out _))
        {
            return true;
        }
        return false;
    }
    private static bool IsPositiveInteger(string? input)
    {
        if (int.TryParse(input, out int inputInteger))
        {
            if (inputInteger > 0)
            {
                return true;
            }
        }
        return false;
    }
}
