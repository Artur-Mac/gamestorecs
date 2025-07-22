using System;
using GameStore.DTOS;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{
    private static string GetGamesEndpoint = "GetGame";

    public static readonly List<GameDTO> games = [    new GameDTO(1, "Elden Ring", "RPG", 299.99m, new DateOnly(2022, 2, 25)),
    new GameDTO(2, "Hades", "Roguelike", 99.99m, new DateOnly(2020, 9, 17)),
    new GameDTO(3, "Celeste", "Platformer", 49.99m, new DateOnly(2018, 1, 25))
    ];
    public static WebApplication MapGamesEndpoints(this WebApplication app) {
        var gm = app.MapGroup("/games");
        
        gm.MapGet("/{id?}", (int? id) =>{
           if (id == null){
            return Results.Ok(games);
           }
           if (games.Find(game => game.Id == id) == null){
                return Results.NotFound();
           }
           return Results.Ok(games);
        });
        return app;
    }
}
