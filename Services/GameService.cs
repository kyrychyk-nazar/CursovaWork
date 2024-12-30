namespace CourseWork;

public class GameService : IGameService
{
    public IGameRepo gameRepo { get; }
    public IUserRepo userRepo { get; }

    public GameService(IGameRepo gameRepo, IUserRepo userRepo)
    {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
    }
    
    public void CreateGame(int player1ID, int player2ID, int gameType, int rating = 0)
    {
        var player1 = userRepo.GetUserById(player1ID);
        var player2 = userRepo.GetUserById(player2ID);
        if (player1 == null)
        {
            Console.WriteLine($"Player with id {player1ID} is not found");
            return;
        }
        if (player2 == null)
        {
            Console.WriteLine($"Player with id {player2ID} is not found");
            return;
        }
        var game = Factory.CreateGame(player1, player2, gameType, rating);
        
        gameRepo.AddGame(game);
        game.Play();
        
        player1.GameResult(game);
        player2.GameResult(game);
    }

    public void DisplayGameById(int id)
    {
        var game = gameRepo.GetGameById(id);
        if (game != null)
        {
            Console.WriteLine("---------------------");
            if (game.GetType() != typeof(TrainingGame))
            {
                Console.WriteLine(
                    $"Game ID: {game.GameID} \nGame type: {game.GameType}\nWinner: {game.Winner.UserName}" +
                    $"\nLooser: {game.Looser.UserName} \nPoints: {game.Points}");
            }
            else
                Console.WriteLine($"Game ID: {game.GameID} \nGame type: {game.GameType}\nWinner: {game.Winner.UserName}" +
                                  $"\nLooser: {game.Looser.UserName}");
            
        }
        else
        {
            Console.WriteLine($"Game with id {id} not found");
        }
    }

    public void DisplayAllGames()
    {
        var games = gameRepo.GetAllGames();
        if (games.Count != 0)
        {
            foreach (var game in games)
            {
                DisplayGameById(game.GameID);
            }
        }else Console.WriteLine("No games played yet");
    }

    public void DeleteGame(int id)
    {
        var gameToRemove = gameRepo.GetGameById(id);
        if (gameToRemove != null)
        {
            gameRepo.DeleteGame(gameToRemove);
        }
        else
        {
            Console.WriteLine($"There is no game with id: {id}");
            return;
        }
    }
}