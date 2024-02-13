using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Repositories;
using GameArchive.Repositories.Extensions;

namespace GameArchive.Logic;

internal class BoardGameLogic
{
    SqlRepository<BoardGame> boardGameRepository = new SqlRepository<BoardGame>(new GameArchiveDbContext());

    public void AddBoardGame()
    {
        Console.WriteLine("Insert name");
        var gameName = Console.ReadLine();
        Console.WriteLine("Insert category");
        var gameCategory = Console.ReadLine();
        Console.WriteLine("Insert publication year");
        var gamePublicationYear = ConvertStringToInteger(Console.ReadLine());
        Console.WriteLine("Insert producer");
        var gameProducer = Console.ReadLine();
        Console.WriteLine("Insert maximum amount of players");
        var maxPlayers = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = new BoardGame { Name = gameName, Category = gameCategory, PublicationYear = gamePublicationYear, Producer = gameProducer, MaxPlayers = maxPlayers };

        boardGameRepository.AddGame(boardGame);
    }

    public void DisplayBoardGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = boardGameRepository.FindGameById(gameId);
        Console.WriteLine(boardGame.Name);
    }

    public void DisplayAllBoardGames()
    {
        var boardGames = boardGameRepository.GetAll();
        foreach (var boardGame in boardGames)
        {
            Console.WriteLine(boardGame);
            Console.WriteLine();
        }
    }

    public void RemoveBoardGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = boardGameRepository.FindGameById(gameId);
        boardGameRepository.RemoveGame(boardGame);
    }
    public Boolean ConvertStringToBoolean(string input)
    {
        if (input == "yes")
        {
            return true;
        }
        else if (input == "no")
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
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            throw new Exception("String is not a integer!");
        }
    }
}
