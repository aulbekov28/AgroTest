using Company.Delivery.Core;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    private readonly DeliveryDbContext _deliveryDbContext;

    public WaybillService(DeliveryDbContext deliveryDbContext) => _deliveryDbContext = deliveryDbContext;

    private static Func<Waybill, WaybillDto> MapToWaybillDto => wb => new WaybillDto
    {
        Id = wb.Id,
        Number = wb.Number,
        Date = wb.Date,
        Items = wb.Items?.Select(i => new CargoItemDto
        {
            Id = i.Id,
            WaybillId = i.WaybillId,
            Number = i.Number,
            Name = i.Name,
        }).ToArray()
    };

    public async Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var waybill = await _deliveryDbContext
            .Waybills
            .AsNoTracking()
            .Select(w => new WaybillDto
            {
                Id = w.Id,
                Number = w.Number,
                Date = w.Date,
                Items = w.Items != null
                    ? w.Items.Select(i => new CargoItemDto
                    {
                        Id = i.Id,
                        WaybillId = i.WaybillId,
                        Number = i.Number,
                        Name = i.Name,
                    }).ToArray()
                    : null
            })
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken)
            .ConfigureAwait(false);

        // Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException
        if (waybill is null)
        {
            throw new EntityNotFoundException();
        }

        return waybill;
    }

    public async Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        var waybill = new Waybill
        {
            Number = data.Number,
            Date = data.Date,
            Items = data.Items?.Select(i => new CargoItem
            {
                Name = i.Name,
                Number = i.Number
            }).ToArray()
        };

        _deliveryDbContext.Waybills
            .Add(waybill);

        await _deliveryDbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToWaybillDto(waybill);
    }

    public async Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        var waybill = await _deliveryDbContext
            .Waybills
            .Include(x => x.Items)
            .FirstOrDefaultAsync(wb => wb.Id == id, cancellationToken);

        // Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException
        if (waybill is null)
        {
            throw new EntityNotFoundException();
        }

        waybill.Date = data.Date;
        waybill.Number = data.Number;
        waybill.Items = data.Items?.Select(i => new CargoItem
        {
            Name = i.Name,
            Number = i.Number
        }).ToList();

        await _deliveryDbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToWaybillDto(waybill);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var waybill = _deliveryDbContext.Waybills.Attach(
                new Waybill
                {
                    Id = id,
                    Number = null!
                });
            waybill.State = EntityState.Deleted;
            await _deliveryDbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        catch (DbUpdateConcurrencyException) // Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException
        {
            throw new EntityNotFoundException();
        }
    }
}