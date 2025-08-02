using System;
using GameStore.Datas;
using GameStore.DTOS;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{
    private static readonly string getGamesEndpoint = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app) {
        var gm = app.MapGroup("/games")
        .WithParameterValidation();
        
        gm.MapGet("/{id?}",  async (int? id, GameStoreContext DbContext) =>{
           if (id is null){
                List<GameSummaryDTO> games = await DbContext.Games
                   .Include(game => game.Genre)
                   .Select(game => game.ToGameSummaryDTO())
                   .AsNoTracking()
                   .ToListAsync();

             return Results.Ok(games);
           }

           Game? gameGet = await DbContext.Games.FindAsync(id);
           
           if (gameGet == null)
            {
                return Results.NotFound("Game Not Found -> input a valid ID");
            }
           
           return Results.Ok(gameGet.ToGameDetailsDTO());
        }).WithName(getGamesEndpoint);


        gm.MapPost("/", async (CreateGameDTO game, GameStoreContext DbContext)=>{
            Game newGame = game.ToGame();

            await DbContext.Games.AddAsync(newGame);
            await DbContext.SaveChangesAsync();

        
            return Results.CreatedAtRoute(getGamesEndpoint,
            new { id = newGame.Id },
            newGame.ToGameDetailsDTO());
        });
        

        gm.MapPut("/{id}", async (int id, UpdateGameDTO game, GameStoreContext DbContext)=>
        {
            Game? exsitingGame = await DbContext.Games.FindAsync(id);

            if (exsitingGame == null)
            {
                return Results.NotFound();
            }
            
            DbContext.Entry(exsitingGame).CurrentValues.SetValues(game.ToGame(id));
            await DbContext.SaveChangesAsync();

            return Results.NoContent();
            
        });

        gm.MapDelete("/{id}",async (int id, GameStoreContext DbContext)=>
        {
            await DbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

            await DbContext.SaveChangesAsync();
            return Results.NoContent();
        });


        return gm;
    }
}
/*
Things to do:
-Atualize sumary and details
-atualize updatedto
-entity to dto


*/