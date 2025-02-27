```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3207)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                              | Mean      | Error     | StdDev    | Median    |
|------------------------------------ |----------:|----------:|----------:|----------:|
| Guid_Compare_Equal_Guid             | 0.0016 ns | 0.0045 ns | 0.0037 ns | 0.0000 ns |
| Guid256_Compare_Equal_Guid256       | 7.6808 ns | 0.0213 ns | 0.0189 ns | 7.6806 ns |
| Guid256_Compare_EqualVector_Guid256 | 0.5986 ns | 0.0415 ns | 0.0388 ns | 0.5779 ns |
