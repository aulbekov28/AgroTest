namespace Company.Delivery.Api.Controllers.Waybills.Request;

/// <summary>
/// Cargo item
/// </summary>
public class CargoItemCreateRequest
{
    /// <summary>
    /// Number
    /// </summary>
    public required string Number { get; init; }

    /// <summary>
    /// Name
    /// </summary>
    public required string Name { get; init; }
}