namespace CourseWork;

public class DeletePlayer : ICommand
{
    public IUserService userService { get; }

    public DeletePlayer(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter username of Account you want to delete:");
        string nameInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nameInput))
        {
            Console.WriteLine("Name cannot be empty.");
            return;
        }

        var username = nameInput;

        var account = userService.GetRegisteredUser(username);
        if (account == null)
        {
            Console.WriteLine($"There is no user with name {username}");
            return;
        }
        userService.DisplayUserInfo(account.UserID);
        Console.WriteLine("Enter password from this account:");
        var passwdInput = Console.ReadLine();
        if (!passwdInput.Equals(account.Password, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid password.");
            return;
        }
        
        userService.DeleteUser(username);
        Console.WriteLine($"User with name {username} deleted successfully");
    }

    public string GetInfo()
    {
        return "Delete account by user name";
    }
}