using GameArchive.Data.DataProvider;
using GameArchive.Data.Entities;
using GameArchive.UserCommuniation;

namespace GameArchive;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    
    public App(IUserCommunication userCommunication)
    {
        _userCommunication = userCommunication;      
    }
    public void Run()
    {
        _userCommunication.RunApp();
    }
}
