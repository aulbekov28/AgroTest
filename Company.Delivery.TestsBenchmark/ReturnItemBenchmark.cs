using BenchmarkDotNet.Attributes;
using Company.Delivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Company.Delivery.TestsBenchmark;

[MemoryDiagnoser]
public class ReturnItemBenchmark
{
    [Benchmark]
    public void GetThrows()
    {
        for (var i = 0; i < 100_000; i++)
        {
            IActionResult response;
            try
            {
                response = new OkObjectResult(GetItemThrows.Get(i));
            }
            catch (EntityNotFoundException)
            {
                response = new NotFoundResult();
            }
            var _ = response;
        }
    }

    [Benchmark]
    public void GetOneOf()
    {
        for (var i = 0; i < 100_000; i++)
        {
            var result = GetItemOneOf.Get(i);
            var response = result.Match<IActionResult>(
                wb => new OkObjectResult(wb),
                _ => new NotFoundResult());
            var _ = response;
        }
    }
}