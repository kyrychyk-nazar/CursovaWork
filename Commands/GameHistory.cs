namespace CourseWork;

public class GameHistory : ICommand
{
    public IGameService gameService { get; }

    public GameHistory(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public void Execute()
    {
        gameService.DisplayAllGames();
    }

    public string GetInfo()
    {
        return "Show games history";
    }
}