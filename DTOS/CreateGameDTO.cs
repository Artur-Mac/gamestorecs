namespace GameStore.DTOS;


public record class CreateGameDTO( string Name, string Genre, decimal Price, DateOnly Date);
