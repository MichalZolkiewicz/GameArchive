﻿using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;

namespace GameArchive.Logic;

public class BoardGameLogic<T> : IGameLogic <T> where T : class
{
    private readonly IRepository<BoardGame> _boardGameRepository;
    private readonly IEventLoggerLogic _eventLoggerLogic;

    public BoardGameLogic(IRepository<BoardGame> boardGameRepository, IEventLoggerLogic eventLoggerLogic)
    {
        _boardGameRepository = boardGameRepository;
        _eventLoggerLogic = eventLoggerLogic;
    }

    public void AddGame()
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

        _boardGameRepository.ItemAdded += _eventLoggerLogic.GameRepositoryOnItemAdded;
        _boardGameRepository.Add(boardGame);
        _boardGameRepository.Save();
    }

    public void DisplayGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = _boardGameRepository.GetById(gameId);
        Console.WriteLine(boardGame.Name);
    }

    public void DisplayAllGames()
    {
        var boardGames = _boardGameRepository.GetAll();
        foreach (var boardGame in boardGames)
        {
            Console.WriteLine(boardGame);
            Console.WriteLine();
        }
    }

    public void UpdateVideoGame(string id)
    {

        var boardGame = _boardGameRepository.GetById(this.ConvertStringToInteger(id));
        Console.WriteLine("=========================================");
        Console.WriteLine("What would you like to change?");
        Console.WriteLine("\nA => Name\nB => Category\nC => Publication year\nD => Producer\nE => Online option");
        var input = Console.ReadLine();
        if (boardGame != null)
        {
            switch (input)
            {
                case "A":
                case "a":
                    Console.WriteLine("Insert new name");
                    var name = Console.ReadLine();
                    boardGame.Name = name;
                    break;
                case "B":
                case "b":
                    Console.WriteLine("Insert new category");
                    var category = Console.ReadLine();
                    boardGame.Category = category;
                    break;
                case "C":
                case "c":
                    Console.WriteLine("Insert new publication year");
                    var publicationYear = Console.ReadLine();
                    boardGame.PublicationYear = this.ConvertStringToInteger(publicationYear);
                    break;
                case "D":
                case "d":
                    Console.WriteLine("Insert new producer");
                    var producer = Console.ReadLine();
                    boardGame.Producer = producer;
                    break;
                case "E":
                case "e":
                    Console.WriteLine("Insert maximum amout of players");
                    var maxPlayers = Console.ReadLine();
                    boardGame.MaxPlayers = this.ConvertStringToInteger(maxPlayers);
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }

        _boardGameRepository.Save();
    }

    public void RemoveGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = _boardGameRepository.GetById(gameId);
        _boardGameRepository.ItemRemoved += _eventLoggerLogic.GameRepositoryOnItemRemoved;
        _boardGameRepository.Remove(boardGame);
        _boardGameRepository.Save();
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
