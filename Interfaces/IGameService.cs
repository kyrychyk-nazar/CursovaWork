namespace CourseWork;

public interface IGameService
{
    void DisplayAllGames();
    void DisplayGameById(int id);
    void CreateGame(int player1ID, int player2ID, int gameType, int rating = 0);
    void DeleteGame(int id);
    
}
