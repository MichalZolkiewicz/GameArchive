using GameArchive.Data;
using GameArchive.Data.DataProvider;
using GameArchive.Data.Entities;
using GameArchive.UserCommuniation;

namespace GameArchive;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly GameArchiveDbContext _gameArchiveDbContext;

    public App(IUserCommunication userCommunication, GameArchiveDbContext gameArchiveDbContext)
    {
        _userCommunication = userCommunication;
        _gameArchiveDbContext = gameArchiveDbContext;
        _gameArchiveDbContext.Database.EnsureCreated();
    }
    public void Run()
    {
        _userCommunication.RunApp();
    }
}
