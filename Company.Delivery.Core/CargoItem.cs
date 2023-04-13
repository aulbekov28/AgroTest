namespace Company.Delivery.Core;

public class CargoItem
{
    public Guid Id { get; set; }

    public Guid WaybillId { get; set; }

    public Waybill? Waybill { get; set; }

    // Уникальное значение в пределах сущности Waybill
    public required string Number { get; set; }

    public required string Name { get; set; }
}