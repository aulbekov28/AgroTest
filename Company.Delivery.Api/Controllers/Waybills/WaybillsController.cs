using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Company.Delivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Company.Delivery.Api.Controllers.Waybills;

/// <summary>
/// Waybills management
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WaybillsController : ControllerBase
{
    private readonly IWaybillService _waybillService;

    /// <summary>
    /// Waybills management
    /// </summary>
    public WaybillsController(IWaybillService waybillService) => _waybillService = waybillService;

    /// <summary>
    /// Получение Waybill
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // вернуть ответ с кодом 200 если найдено или кодом 404 если не найдено
        // WaybillsControllerTests должен выполняться без ошибок
        try
        {
            var waybill = await _waybillService.GetByIdAsync(id, cancellationToken);
            return Ok(WaybillResponse.FromWaybill(waybill));
        }
        catch (EntityNotFoundException)
        {
            return new NotFoundResult();
        }
    }

    /// <summary>
    /// Создание Waybill
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] WaybillCreateRequest request, CancellationToken cancellationToken)
    {
        // вернуть ответ с кодом 200 если успешно создано
        // WaybillsControllerTests должен выполняться без ошибок
        var result = await _waybillService.CreateAsync(request.ToCreateDto(), cancellationToken);
        return Ok(WaybillResponse.FromWaybill(result));
    }

    /// <summary>
    /// Редактирование Waybill
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateByIdAsync(Guid id, [FromBody] WaybillUpdateRequest request, CancellationToken cancellationToken)
    {
        // вернуть ответ с кодом 200 если найдено и изменено, или 404 если не найдено
        // WaybillsControllerTests должен выполняться без ошибок
        try
        {
            var result = await _waybillService.UpdateByIdAsync(id, request.ToUpdateDto(), cancellationToken);
            return Ok(WaybillResponse.FromWaybill(result));
        }
        catch (EntityNotFoundException)
        {
            return new NotFoundResult();
        }
    }

    /// <summary>
    /// Удаление Waybill
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // вернуть ответ с кодом 200 если найдено и удалено, или 404 если не найдено
        // WaybillsControllerTests должен выполняться без ошибок
        try
        {
            await _waybillService.DeleteByIdAsync(id, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return new NotFoundResult();
        }


        return Ok();
    }
}