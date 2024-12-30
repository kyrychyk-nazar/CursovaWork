namespace CourseWork;

public class DeleteGame : ICommand
{
    public IGameService gameService { get; }

    public DeleteGame(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter game ID:");
        string idInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(idInput))
        {
            Console.WriteLine("Game ID cannot be empty.");
            return;
        }
        var id = int.Parse(idInput);
        if (id <= 0)
        {
            Console.WriteLine("Game ID cannot be zero or below");
            return;
        }
        gameService.DeleteGame(id);
        Console.WriteLine($"Game with ID {id} deleted");
    }

    public string GetInfo()
    {
        return "Delete a game by ID";
    }
}