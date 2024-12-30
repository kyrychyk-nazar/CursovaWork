namespace CourseWork;

public class DisplayUserInfo : ICommand
{
    public IUserService userService { get; }

    public DisplayUserInfo(IUserService userService)
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
            return;
        }
        userService.DisplayUserInfo(id);
    }

    public string GetInfo()
    {
        return "Display player information";
    }
}