namespace Company.Delivery.Api.Controllers.Waybills.Response;

/// <summary>
/// Cargo item
/// </summary>
public class CargoItemResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Waybill Id
    /// </summary>
    public Guid WaybillId { get; init; }

    /// <summary>
    /// Number
    /// </summary>
    public required string Number { get; init; }

    /// <summary>
    /// Name
    /// </summary>
    public required string Name { get; init; }
}