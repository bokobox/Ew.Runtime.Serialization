``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.765 (1803/April2018Update/Redstone4)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|       Method |     Mean |     Error |    StdDev |
|------------- |---------:|----------:|----------:|
|  MessagePack | 188.0 ns |  3.649 ns |  4.481 ns |
| EwSerializer | 708.0 ns | 15.905 ns | 14.878 ns |
