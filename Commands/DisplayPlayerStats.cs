namespace CourseWork;

public class DisplayPlayerStats : ICommand
{
    public IUserService userService { get; }

    public DisplayPlayerStats(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter player ID:");
        string idInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(idInput))
        {
            Console.WriteLine("ID cannot be empty.");
            return;
        }
        var id = int.Parse(idInput);
        if (id <= 0)
        {
            Console.WriteLine("ID cannot be zero or below");
        }
        userService.DisplayUserStats(id);
    }

    public string GetInfo()
    {
        return "Show player current stats";
    }
}