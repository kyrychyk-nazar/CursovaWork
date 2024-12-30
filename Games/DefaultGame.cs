using System.Xml.Schema;

namespace CourseWork;

public class DefaultGame : Game
{
    public override string GameType => "Default Game";
    public DefaultGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2)
    {
        Points = rating;
    }
    protected override void HandleGameEnd(GameAccount winner, GameAccount loser)
    {
        if (winner != null && loser != null)
        {
            Console.WriteLine($"{winner.UserName} won {loser.UserName} and received {Points} points.");
            Winner = winner;
            Looser = loser;
        }
        else
        {
            Console.WriteLine("No points awarded for a draw.");
        }
    }
}