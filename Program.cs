using GameStore.Datas;
using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string connString = "Db Source=GameStoreContext.db";
builder.Services.AddSqlite<GameStoreContext>(connString);

app.MapGamesEndpoints();
app.Run();
