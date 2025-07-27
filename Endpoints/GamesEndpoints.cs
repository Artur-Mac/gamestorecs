using System;
using GameStore.Datas;
using GameStore.DTOS;
using GameStore.Entities;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{
    private static string getGamesEndpoint = "GetGame";

    public static readonly List<GameDTO> games = [    new GameDTO(1, "Elden Ring", "RPG", 299.99m, new DateOnly(2022, 2, 25)),
    new GameDTO(2, "Hades", "Roguelike", 99.99m, new DateOnly(2020, 9, 17)),
    new GameDTO(3, "Celeste", "Platformer", 49.99m, new DateOnly(2018, 1, 25))
    ];
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app) {
        var gm = app.MapGroup("/games")
        .WithParameterValidation();
        
        gm.MapGet("/{id?}", (int? id) =>{
           if (id == null){
            return Results.Ok(games);
           }
           GameDTO? gameGet = games.Find(game => game.Id == id);
           if ( gameGet== null){
                return Results.NotFound("passou aqui");
           }
           
           return Results.Ok(gameGet);
        }).WithName(getGamesEndpoint);


        gm.MapPost("/", (CreateGameDTO game, GameStoreContext DbContext)=>{
            Game newGame = new()
            {
                Name = game.Name,
                Genre = DbContext.Genres.Find(game.GenreId),
                GenreId = game.GenreId,
                Price = game.Price,
                Date = game.Date

            };

            DbContext.Games.Add(newGame);

            return Results.CreatedAtRoute(getGamesEndpoint, new { id = newGame.Id }, game);
        });
        

        gm.MapPut("/{id}", (int id, UpdateGameDTO game)=>
        {
            int idGame = games.FindIndex(g => g.Id == id);

            if (idGame == -1)
            {
                return Results.NotFound();
            }

            games[idGame] = new(id, game.Name, game.Genre, game.Price, game.Date);

            return Results.NoContent();
            
        });

        gm.MapDelete("/{id}", (int id)=>
        {
            GameDTO? game = games.Find(game => game.Id == id);
            if (game == null)
            {
                return Results.NotFound();
            }

            games.Remove(game);
            return Results.NoContent();
        });


        return gm;
    }
}
// How to create requirementes (ex: date need to be before future?)
// Am I forgotting something?