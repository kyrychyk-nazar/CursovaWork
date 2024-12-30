namespace CourseWork;

public interface IGameRepo
{
    void AddGame(Game game);
    List<Game> GetAllGames();
    Game? GetGameById(int id);
    void DeleteGame(Game gameToRemove);
    List<Game> GetGamesByPlayerID(int id);
}

