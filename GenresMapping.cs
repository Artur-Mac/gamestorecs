using System;
using GameStore.DTOS;
using GameStore.Entities;

namespace GameStore;

public static class GenresMapping
{
    public static GenresDetailsDTO ToGenresDetailsDTO(this Genre genre)
    {
        return new(
            genre.Id,
            genre.Name);
    }
}

