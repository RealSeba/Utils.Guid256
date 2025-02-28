```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3207)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                                         | Mean        | Error     | StdDev    | Median      |
|----------------------------------------------- |------------:|----------:|----------:|------------:|
| Guid_Create                                    |  74.8572 ns | 1.3187 ns | 1.1690 ns |  74.4903 ns |
| Guid256_Create                                 | 127.8420 ns | 0.4406 ns | 0.4121 ns | 127.7301 ns |
| Guid_Compare_Unequal_Guid                      | 254.0416 ns | 5.1020 ns | 7.6364 ns | 256.8759 ns |
| Guid256_Compare_Unequal_Guid256                | 288.0468 ns | 5.4781 ns | 6.3086 ns | 289.4676 ns |
| Guid_Create_ToString_ParseBack                 | 192.3800 ns | 3.7851 ns | 3.7174 ns | 193.2059 ns |
| Guid256_Create_ToString_ParseBack              | 215.0456 ns | 2.5021 ns | 2.3405 ns | 215.2803 ns |
| Guid_Json_Serialize_Deserialize_EqualsCheck    | 422.3791 ns | 2.8267 ns | 2.5058 ns | 421.4676 ns |
| Guid256_Json_Serialize_Deserialize_EqualsCheck | 539.4219 ns | 4.7906 ns | 4.2467 ns | 538.7524 ns |
| Guid_Equals_Guid                               |   0.0009 ns | 0.0028 ns | 0.0026 ns |   0.0000 ns |
| Guid256_EqualsVector_Guid256                   |   0.9035 ns | 0.0153 ns | 0.0128 ns |   0.9049 ns |
