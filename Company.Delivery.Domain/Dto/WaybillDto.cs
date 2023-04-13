namespace Company.Delivery.Domain.Dto;

public class WaybillDto
{
    public Guid Id { get; init; }

    public required string Number { get; init; }

    public DateTime Date { get; init; }

    public IEnumerable<CargoItemDto>? Items { get; init; }
}