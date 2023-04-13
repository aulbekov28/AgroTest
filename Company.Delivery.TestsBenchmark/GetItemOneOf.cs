using Company.Delivery.Domain.Dto;
using OneOf;
using OneOf.Types;

namespace Company.Delivery.TestsBenchmark;

public class GetItemOneOf
{
    internal static OneOf<WaybillDto, NotFound> Get(int id)
    {
        if (id % 10 == 0)
        {
            return new NotFound();
        }

        return new WaybillDto { Id = Guid.Empty, Number = string.Empty };
    }
}