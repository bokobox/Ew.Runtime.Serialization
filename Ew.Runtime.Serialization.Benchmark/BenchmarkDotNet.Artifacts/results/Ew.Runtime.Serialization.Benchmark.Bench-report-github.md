``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.765 (1803/April2018Update/Redstone4)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|       Method |     Mean |    Error |    StdDev |   Median |
|------------- |---------:|---------:|----------:|---------:|
| EwSerializer | 362.4 ns | 7.396 ns | 15.273 ns | 356.6 ns |
|  MessagePack | 404.0 ns | 7.656 ns |  7.162 ns | 401.1 ns |
