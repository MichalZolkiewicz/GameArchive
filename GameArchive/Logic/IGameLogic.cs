namespace GameArchive.Logic;

public interface IGameLogic<T> where T : class
{
    void AddGame();
    void DisplayGameById();
    void DisplayAllGames();
    void RemoveGame();

    void UpdateGame(string id);
}
