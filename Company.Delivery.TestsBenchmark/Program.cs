using BenchmarkDotNet.Running;
using Company.Delivery.TestsBenchmark;

BenchmarkRunner.Run<ReturnItemBenchmark>();

/*
|    Method |      Mean |     Error |    StdDev |      Gen0 | Allocated |
|---------- |----------:|----------:|----------:|----------:|----------:|
| GetThrows | 84.032 ms | 1.4806 ms | 1.4542 ms | 3857.1429 |  23.27 MB |
|  GetOneOf |  4.196 ms | 0.0828 ms | 0.1360 ms | 3250.0000 |  19.45 MB |
 */