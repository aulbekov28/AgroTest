namespace Company.Delivery.Domain.Dto;

public class WaybillUpdateDto
{
    public required string Number { get; init; }

    public DateTime Date { get; init; }

    public IEnumerable<CargoItemUpdateDto>? Items { get; init; }
}