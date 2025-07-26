using GameStore.Datas;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);


string connString = builder.Configuration.GetConnectionString("AppSettingsDbContext");

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();
app.MapGamesEndpoints();


app.Run();


/*
-connection string

-download dependencies

-update "schema" every new update
*/