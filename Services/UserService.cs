namespace CourseWork;

public class UserService : IUserService
{
    public IUserRepo userRepo { get; }
    public IGameRepo gameRepo { get; }
    
    public int LoggedInUserId { get; set; }

    public UserService(IUserRepo userRepo, IGameRepo gameRepo)
    {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
    }

    public void RegisterUser(string username, string hashedPassword, int accountType)
    {
        if (userRepo.GetUserByName(username) != null)
        {
            Console.WriteLine($"User with name {username} already exists");
        }
        GameAccount gameAccount;
        if (accountType == 2) gameAccount = new PayForWinAcc(username, hashedPassword);
        else gameAccount = new GameAccount(username, hashedPassword);
        userRepo.AddUser(gameAccount);
    }

    public void DisplayUserInfo(int id)
    {
        var user = userRepo.GetUserById(id);
        if (user != null)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine(
                $"User ID: {user.UserID}\nName: {user.UserName}\nCurrent rating: {user.CurrentRating}\nAccount type:{user.AccountType}");
            Console.WriteLine("---------------------------");
        }
        else
        {
            Console.WriteLine($"User with id {id} not found");
            return;
        }
    }

    public void DisplayUserStats(int id)
    {
        var user = userRepo.GetUserById(id);
        if (user != null)
        {
            Console.WriteLine("+--------+----------------+----------+--------+");
            Console.WriteLine($"         {user.UserName}'s game history            ");
            Console.WriteLine("+--------+----------------+----------+--------+");
            Console.WriteLine($"         Current rating:{user.CurrentRating}        ");
            Console.WriteLine("+--------+----------------+----------+--------+");
            var userGames = gameRepo.GetGamesByPlayerID(id);
            if (userGames.Count == 0)
            {
                Console.WriteLine("|            No games played yet.             |");
            }
            else
            {
                Console.WriteLine("| GameID |    Opponent    |  Result  | Points |");
                Console.WriteLine("+--------+----------------+----------+--------+");

                foreach (var game in userGames)
                {
                    var opponent = game.Winner == user ? game.Looser.UserName : (game.Winner == null ? "Draw" : game.Winner.UserName);
                    var result = game.Winner == user ? "Win" : (game.Winner == null ? "Draw" : "Loss");
                    var points = game.Points;
                    var gameId = game.GameID;

                    Console.WriteLine($"| {gameId,-6} | {opponent,-14} | {result,-8} | {points,-6} |");
                }
            }

            Console.WriteLine("+--------+----------------+----------+-------+");
        }
        else
        {
            Console.WriteLine($"User with id {id} not found");
            return;
        }
    }

    public void DisplayAllUsers()
    {
        foreach (var user in userRepo.GetAllUsers())
        { 
            Console.WriteLine($"ID: {user.UserID} Name: {user.UserName}");
        }
    }

    public void DeleteUser(string username)
    {
        var accountToRemove = userRepo.GetUserByName(username);
        if (accountToRemove != null)
        {
            userRepo.DeleteUser(accountToRemove);
        }
        else
        {
            Console.WriteLine($"There is no user with name: {username}");
        }
    }


    public void UpdateUser(int id, string newName)
    {
        var accountToUpdate = userRepo.GetUserById(id);
        if (accountToUpdate == null)
        {
            Console.WriteLine($"There is no user with this id: {id}");
            return;
        }
        if (userRepo.GetUserByName(newName) == null)
        {
            userRepo.UpdateUser(accountToUpdate, newName);
        }
        else
        {
            Console.WriteLine($"User with username \" {newName}\"already exists");
            return;
        }
    }

    public void LoginUser(string username, string hashedPasswordInput)
    {
        var user = userRepo.GetUserByName(username);
        if (user != null && user.Password == hashedPasswordInput)
        {
            LoggedInUserId = user.UserID;
            Console.WriteLine($"User {username} logged in successfully.");
            return;
        }
        Console.WriteLine("Invalid username or password.");
    }

    public GameAccount? GetRegisteredUser(string username)
    {
        return userRepo.GetUserByName(username);
    }
    
    public void Logout()
    {
        LoggedInUserId = 0;
        Console.WriteLine("You logged out.");
    }
    
}
