namespace CourseWork;

public class PlayGame : ICommand
{
    public IGameService gameService { get; }
    public IUserService userService { get; }

    public PlayGame(IGameService gameService, IUserService userService)
    {
        this.gameService = gameService;
        this.userService = userService;
    }

    public void Execute()
    {
        bool ind = true;
        while (ind)
        {
            int rating = 0;

            if (userService.LoggedInUserId == 0)
            {
                Console.WriteLine("You need to log in first");
                return;
            }
            var player1 = userService.LoggedInUserId;
            Console.WriteLine("Enter opponent ID: ");
            var player2 = int.Parse(Console.ReadLine());
            if (player2 == player1)
            {
                Console.WriteLine("You can't play againts yourself.");
                continue;
            }
            Console.WriteLine("Enter game type(1 - Standart, 2 - Training): ");
            var gameType = int.Parse(Console.ReadLine());
            if (gameType > 2 || gameType < 0)
            {
                Console.WriteLine("Invalid game type index, pick from 1 to 2");
                continue;
            }

            if (gameType == 1)
            {
                Console.WriteLine("Enter points playing for:");
                rating = int.Parse(Console.ReadLine());
            }
            gameService.CreateGame(player1, player2, gameType, rating);
            ind = false;
        }
    }

    public string GetInfo()
    {
        return "Play a game";
    }
}