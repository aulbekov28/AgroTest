using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Api.Controllers.Waybills.Request;

/// <summary>
/// Waybill
/// </summary>
public class WaybillUpdateRequest
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
    public IEnumerable<CargoItemUpdateRequest>? Items { get; init; }

    /// <summary>
    /// Convert request to updateDto object
    /// </summary>
    /// <returns></returns>
    public WaybillUpdateDto ToUpdateDto() =>
        new()
        {
            Number = Number,
            Date = Date,
            Items = Items?.Select(x => new CargoItemUpdateDto()
            {
                Number = x.Number,
                Name = x.Name,
            })
        };
}