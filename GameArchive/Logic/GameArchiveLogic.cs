using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Repositories;
using GameArchive.Repositories.Extensions;

namespace GameArchive.Logic;

public class GameArchiveLogic
{
    SqlRepository<VideoGame> videoGameRepository = new SqlRepository<VideoGame>(new GameArchiveDbContext());

    SqlRepository<BoardGame> boardGameRepository = new SqlRepository<BoardGame>(new GameArchiveDbContext());

    public SqlRepository<VideoGame> GetVideoGameRepository()
    {
        return videoGameRepository;
    }

    public SqlRepository<BoardGame> GetBoardGameRepository()
    {
        return boardGameRepository;
    }

    public VideoGame CreateVideoGame()

    public Boolean ConvertStringToBoolean(string input)
    {
        if(input == "yes")
        {
            return true;
        }
        else if(input == "no")
        {
            return false;
        }
        else
        {
            throw new Exception("Incorrect wording!");
        }
    }

    public int ConvertStringToInteger(string input)
    {
        if(int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            throw new Exception("String is not a double!");
        }
    }
}
