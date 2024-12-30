namespace CourseWork;

public class DbContext
{
    public List<GameAccount> Gamers { get; } 
    public List<Game> Games { get; } 

    public DbContext()
    {
        Games = new List<Game>();
        Gamers = new List<GameAccount>();
    }
}