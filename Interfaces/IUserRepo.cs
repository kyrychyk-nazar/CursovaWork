namespace CourseWork;

public interface IUserRepo
{
    void AddUser(GameAccount gameAccount);
    GameAccount? GetUserById(int id);
    GameAccount? GetUserByName(string username);
    void UpdateUser(GameAccount accountToUpdate, string newName);
    void DeleteUser(GameAccount accountToRemove);
    List<GameAccount> GetAllUsers();
}
