using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Api.Controllers.Waybills.Response;

/// <summary>
/// Waybill
/// </summary>
public class WaybillResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

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
    public IEnumerable<CargoItemResponse>? Items { get; init; }

    /// <summary>
    /// Convert from waybillDto object
    /// </summary>
    /// <param name="waybill"></param>
    /// <returns></returns>
    public static WaybillResponse FromWaybill(WaybillDto waybill) =>
        new()
        {
            Id = waybill.Id,
            Date = waybill.Date,
            Number = waybill.Number,
            Items = waybill.Items?.Select(x => new CargoItemResponse
            {
                Id = x.Id,
                Number = x.Number,
                Name = x.Name,
                WaybillId = x.WaybillId
            })
        };
}