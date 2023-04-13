namespace Company.Delivery.Core;

public class Waybill
{
    public Guid Id { get; set; }

    // уникальное значение
    public required string Number { get; set; }

    public DateTime Date { get; set; }

    public ICollection<CargoItem>? Items { get; set; }
}