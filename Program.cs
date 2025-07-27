using GameStore.Datas;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

// Check for null and throw a descriptive exception
if (string.IsNullOrEmpty(connString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

// Now it's safe to use the non-null string
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();
app.MigrateDb();
app.MapGamesEndpoints();

app.Run();


/*
-connection string

-download dependencies

-update "schema" every new update
*/