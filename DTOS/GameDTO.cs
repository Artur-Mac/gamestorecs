namespace GameStore.DTOS;

public record class GameDTO(int Id, string Name, string Genre, decimal Price, DateOnly Date);
