namespace MathGame;

internal class Game
{
    internal DateTime StartTime { get; } = DateTime.UtcNow;
    private DateTime _endTime;
    internal DateTime EndTime 
    {
        get { return _endTime; }
        set 
        {
            if (StartTime > value) 
            {
                throw new ArgumentOutOfRangeException(paramName: "EndTime", 
                    message: $"The input EndTime property value '{value}' is earlier than the StartTime property '{this.StartTime}'.");
            }
            else
            {
                _endTime= value;
            }
        } 
    }
    internal int Score { get; set; }
    internal int NumberOfQuestions { get; set; }
    internal GameType Type { get; set; }
    internal GameDifficulty Difficulty { get; set; }

    public override string ToString()
    {
        var duration = (this.EndTime - this.StartTime).ToString(@"hh\:mm\:ss");
        return $"Game type: {this.Type} - Duration: {duration} - Score: {this.Score} / {this.NumberOfQuestions} - Difficulty: {this.Difficulty}";
    }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}

internal enum GameDifficulty
{
    Easy,
    Normal,
    Hard
}