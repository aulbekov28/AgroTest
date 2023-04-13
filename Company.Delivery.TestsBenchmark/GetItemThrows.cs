using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;

namespace Company.Delivery.TestsBenchmark;

public static class GetItemThrows
{
    internal static WaybillDto Get(int id)
    {
        if (id % 10 == 0)
        {
            throw new EntityNotFoundException();
        }

        return new WaybillDto { Id = Guid.Empty, Number = string.Empty };
    }
}