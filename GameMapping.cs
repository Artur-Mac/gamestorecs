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

    public static GameDTO ToDTO(this Game game)
    {
        return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.Date
            );
    }
}
