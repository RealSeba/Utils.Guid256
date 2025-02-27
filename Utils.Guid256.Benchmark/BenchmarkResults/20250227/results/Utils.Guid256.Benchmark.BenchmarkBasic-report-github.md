```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3207)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                                  | Mean      | Error     | StdDev    |
|---------------------------------------- |----------:|----------:|----------:|
| Guid_Equals_Guid                        | 0.0000 ns | 0.0000 ns | 0.0000 ns |
| Guid256_EqualsSequenceEqual_Guid256     | 7.5283 ns | 0.1752 ns | 0.1639 ns |
| Guid256_EqualsVector_Guid256            | 0.8998 ns | 0.0418 ns | 0.0391 ns |
| Guid256_Equals256HardwareVector_Guid256 | 5.8065 ns | 0.0084 ns | 0.0070 ns |
