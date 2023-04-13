using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Api.Controllers.Waybills.Request;

/// <summary>
/// Waybill
/// </summary>
public class WaybillCreateRequest
{
    /// <summary>
    /// Number
    /// </summary>
    public required string Number { get; init; }

    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// Items
    /// </summary>
    public IEnumerable<CargoItemCreateRequest>? Items { get; init; }

    /// <summary>
    /// Convert request to createDto object
    /// </summary>
    /// <returns></returns>
    public WaybillCreateDto ToCreateDto() =>
        new()
        {
            Number = Number,
            Date = Date,
            Items = Items?.Select(x => new CargoItemCreateDto()
            {
                Number = x.Number,
                Name = x.Name,
            })
        };
}