namespace CourseWork;

public class Exit : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Exiting program...");
        Environment.Exit(0); 
    }

    public string GetInfo()
    {
        return "Exit a program";
    }
    
}