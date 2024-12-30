namespace CourseWork;

public class GameRepo : IGameRepo
{
    public DbContext context { get; }

    public GameRepo(DbContext context)
    {
        this.context = context;
    }

    public void AddGame(Game game)
    {
        context.Games.Add(game);
    }

    public List<Game> GetAllGames()
    {
        return context.Games;
    }

    public Game? GetGameById(int id)
    {
        return context.Games.FirstOrDefault(game => game.GameID == id);
    }

    public void DeleteGame(Game gameToRemove)
    {
        context.Games.Remove(gameToRemove);
    }

    public List<Game> GetGamesByPlayerID(int id)
    {
        return GetAllGames().Where(game => game.Player1.UserID == id || game.Player2.UserID == id).ToList();
    } 
}