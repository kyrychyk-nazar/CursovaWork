namespace CourseWork;

public class DisplayAllPlayers : ICommand
{
    public IUserService userService { get; }

    public DisplayAllPlayers(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        userService.DisplayAllUsers();
    }

    public string GetInfo()
    {
        return "Display all created users";
    }
}