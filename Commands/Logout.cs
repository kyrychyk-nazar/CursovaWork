namespace CourseWork;

public class Logout : ICommand
{
    public IUserService userService { get; }

    public Logout(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        userService.Logout();
    }

    public string GetInfo()
    {
        return "Logout from account";
    }
}