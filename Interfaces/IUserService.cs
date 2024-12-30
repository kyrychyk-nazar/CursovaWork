namespace CourseWork;

public interface IUserService
{
    int LoggedInUserId { get; set; }
    void RegisterUser(string username, string password ,int accountType);
    void DisplayUserInfo(int id);
    void DisplayUserStats(int id);
    void DisplayAllUsers();
    void DeleteUser(string username);
    void UpdateUser(int id, string newName);
    void LoginUser(string username, string password);
    GameAccount? GetRegisteredUser(string username);
    public void Logout();
}
