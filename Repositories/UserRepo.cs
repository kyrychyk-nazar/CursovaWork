namespace CourseWork;

public class UserRepo : IUserRepo
{
    public DbContext context { get; }

    public UserRepo(DbContext context)
    {
        this.context = context;
    }

    public void AddUser(GameAccount gameAccount)
    {
        context.Gamers.Add(gameAccount);
    }

    public GameAccount? GetUserById(int id)
    {
        return context.Gamers.FirstOrDefault(ga => ga.UserID == id);
    }

    public GameAccount? GetUserByName(string username)
    {
        return context.Gamers.Find(ga => ga.UserName == username);
    }

    public void UpdateUser(GameAccount accountToUpdate, string newName)
    {
        accountToUpdate.UserName = newName;
    }

    public void DeleteUser(GameAccount accountToRemove)
    {
        context.Gamers.Remove(accountToRemove);
    }
    
    public List<GameAccount> GetAllUsers()
    {
        return context.Gamers;
    }
    
}
