using System;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Datas;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();
}
