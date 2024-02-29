using GameArchive.ApplicationServices.DataProvider;
using GameArchive.ApplicationServices.Logic;
using GameArchive.Data;
using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;
using GameArchive.UserCommunication;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventLoggerLogic, EventLoggerLogic>();
services.AddSingleton<IRepository<VideoGame>, SqlRepository<VideoGame>>();
services.AddSingleton<IRepository<BoardGame>, SqlRepository<BoardGame>>();
services.AddSingleton<IGameProvider<VideoGame>, VideoGameProvider>();
services.AddSingleton<IGameProvider<BoardGame>, BoardGameProvider>();
services.AddSingleton<IGameArchiveLogic, GameArchiveLogic>();
services.AddSingleton<IGameLogic<VideoGame>, VideoGameLogic>();
services.AddSingleton<IGameLogic<BoardGame>, BoardGameLogic>();

services.AddDbContext<GameArchiveDbContext>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;

app.Run();
