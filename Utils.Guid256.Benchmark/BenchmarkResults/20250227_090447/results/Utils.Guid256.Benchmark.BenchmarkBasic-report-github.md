```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3207)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                        | Mean      | Error     | StdDev    |
|------------------------------ |----------:|----------:|----------:|
| Guid_Compare_Equal_Guid       | 0.0000 ns | 0.0000 ns | 0.0000 ns |
| Guid256_Compare_Equal_Guid256 | 7.5943 ns | 0.0254 ns | 0.0225 ns |
