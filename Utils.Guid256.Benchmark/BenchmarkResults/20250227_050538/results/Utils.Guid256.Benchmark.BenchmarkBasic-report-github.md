```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                                         | Mean        | Error     | StdDev    |
|----------------------------------------------- |------------:|----------:|----------:|
| Guid_Create                                    |  65.9301 ns | 0.8203 ns | 0.7673 ns |
| Guid256_Create                                 | 128.8357 ns | 0.9131 ns | 0.8094 ns |
| Guid_Compare_Unequal_Guid                      | 129.4632 ns | 0.5344 ns | 0.4462 ns |
| Guid256_Compare_Unequal_Guid256                | 267.8388 ns | 3.5786 ns | 3.3475 ns |
| Guid_Create_ToString_ParseBack                 | 110.4804 ns | 1.0673 ns | 0.9462 ns |
| Guid256_Create_ToString_ParseBack              | 204.6251 ns | 3.7614 ns | 3.3343 ns |
| Guid_Compare_Equal_Guid                        |   0.3400 ns | 0.0131 ns | 0.0123 ns |
| Guid256_Compare_Equal_Guid256                  |   6.6068 ns | 0.1111 ns | 0.1040 ns |
| Guid_Json_Serialize_Deserialize_EqualsCheck    | 310.2542 ns | 2.3224 ns | 2.0587 ns |
| Guid256_Json_Serialize_Deserialize_EqualsCheck | 474.3103 ns | 3.8564 ns | 3.0108 ns |
