namespace Company.Delivery.Domain.Dto;

public class CargoItemCreateDto
{
    public required string Number { get; init; }

    public required string Name { get; init; }
}