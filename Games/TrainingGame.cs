namespace CourseWork;

public class TrainingGame : Game
{
    public override string GameType => "Training Game";

    public TrainingGame(GameAccount player1, GameAccount player2) : base(player1, player2)
    {
        Points = 0;
    }
    protected override void HandleGameEnd(GameAccount winner, GameAccount loser)
    {
        Console.WriteLine($"{winner.UserName} won {loser.UserName}");
        Console.WriteLine("No points awarded for a training game.");
        Winner = winner;
        Looser = loser;
    }
}