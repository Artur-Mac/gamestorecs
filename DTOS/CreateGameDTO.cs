using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOS;


public record class CreateGameDTO(
[Required] string Name,
[Required] int GenreId,
[Required] decimal Price,
[Required]DateOnly Date
) : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        DateOnly atual = DateOnly.FromDateTime(DateTime.Now);

        if (Date > atual)
        {
            yield return new ValidationResult($"The date is on future. Its need to be before {atual}", [nameof(Date)]);
        }
    }
}
