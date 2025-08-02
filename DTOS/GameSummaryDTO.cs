namespace GameStore.DTOS;

public record class GameSummaryDTO(int Id, string Name, string Genre, decimal Price, DateOnly Date);
