namespace GameStore.DTOS;

public record class UpdateGameDTO(string Name, string Genre, decimal Price, DateOnly Date);
