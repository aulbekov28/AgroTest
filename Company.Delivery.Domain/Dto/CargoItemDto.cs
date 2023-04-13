namespace Company.Delivery.Domain.Dto;

public class CargoItemDto
{
    public Guid Id { get; init; }

    public Guid WaybillId { get; init; }

    public required string Number { get; init; }

    public required string Name { get; init; }
}