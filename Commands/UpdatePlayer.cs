namespace CourseWork;

public class UpdatePlayer : ICommand
{
    public IUserService userService { get; }

    public UpdatePlayer(IUserService userService)
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
        
        Console.WriteLine("Enter his new name: ");
        string nameInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nameInput))
        {
            Console.WriteLine("New name cannot be empty.");
            return;
        }
        var newName = nameInput;
        userService.UpdateUser(id, newName);
        Console.WriteLine($"User with ID {id} renamed to {newName}");
    }

    public string GetInfo()
    {
        return "Rename player by his id";
    }
}