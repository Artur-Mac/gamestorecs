using System;
using GameStore.DTOS;
using GameStore.Entities;

namespace GameStore;

public static class GameMapping
{
    public static Game ToGame(this CreateGameDTO game)
    {
        return new()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            Date = game.Date

        };
    }

    public static Game ToGame(this UpdateGameDTO game, int id)
    {
        return new()
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            Date = game.Date

        };
    }
    public static GameSummaryDTO ToGameSummaryDTO(this Game game)
    {
        return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.Date
            );
    }
    
    public static GameDetailsDTO ToGameDetailsDTO(this Game game)
    {
        return new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.Date
            );
    }
}
