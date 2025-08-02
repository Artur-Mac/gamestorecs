
using System;
using GameStore.Datas;
using GameStore.DTOS;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        var gen = app.MapGroup("/genres");

        gen.MapGet("/{id?}", async (int? id, GameStoreContext DbContext) =>
        {
            if (id is null)
            {

                List<GenresDetailsDTO> genres = await DbContext.Genres
                   .Select(g => g.ToGenresDetailsDTO())
                   .AsNoTracking()
                   .ToListAsync();
                return Results.Ok(genres);
            }
            
            Genre? genre = await DbContext.Genres.FindAsync(id);

            if (genre is null){
                return Results.NotFound();
            }

            return Results.Ok(genre);
        });

        return gen;
    }

}
