namespace Company.Delivery.Domain.Dto;

public class WaybillCreateDto
{
    public required string Number { get; init; }

    public DateTime Date { get; init; }

    public IEnumerable<CargoItemCreateDto>? Items { get; init; }
}