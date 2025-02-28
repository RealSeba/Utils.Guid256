```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                                         | Mean        | Error     | StdDev    |
|----------------------------------------------- |------------:|----------:|----------:|
| Guid_Create                                    |  66.1123 ns | 0.2553 ns | 0.2388 ns |
| Guid256_Create                                 | 118.3435 ns | 0.7788 ns | 0.6904 ns |
| Guid_Compare_Unequal_Guid                      | 130.2008 ns | 0.2161 ns | 0.1916 ns |
| Guid256_Compare_Unequal_Guid256                | 237.0166 ns | 0.8435 ns | 0.7890 ns |
| Guid_Create_ToString_ParseBack                 | 112.4358 ns | 0.8098 ns | 0.7575 ns |
| Guid256_Create_ToString_ParseBack              | 180.0187 ns | 0.8807 ns | 0.8238 ns |
| Guid_Json_Serialize_Deserialize_EqualsCheck    | 310.7423 ns | 0.4456 ns | 0.3479 ns |
| Guid256_Json_Serialize_Deserialize_EqualsCheck | 465.0249 ns | 3.1759 ns | 2.9707 ns |
| Guid_Equals_Guid                               |   0.0000 ns | 0.0000 ns | 0.0000 ns |
| Guid256_EqualsForLoop_Guid256                  |  16.7125 ns | 0.3533 ns | 0.3132 ns |
| Guid256_EqualsSequenceEqual_Guid256            |   6.3307 ns | 0.0331 ns | 0.0294 ns |
| Guid256_EqualsVector_Guid256                   |   0.3933 ns | 0.0334 ns | 0.0296 ns |
| Guid256_Equals256HardwareVector_Guid256        |   5.6519 ns | 0.0090 ns | 0.0080 ns |
