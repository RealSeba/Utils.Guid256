# Guid256

Guid256 is a lightweight .NET package that provides a custom implementation for working with 256-bit GUIDs. It offers seamless serialization support and it uses System.Security.Cryptography.RandomNumberGenerator to create Random bits.

## Features

- Simple and intuitive API for working with 256-bit GUIDs.
- Custom JSON converter for easy serialization and deserialization.
- Efficient and lightweight implementation.
- System.Security.Cryptography.RandomNumberGenerator to create Random bits.


## Changelog

## [v0.2.0-alpha] - 2025-02-26
### Added

- Added Json serialization and deserialization support.
- Added Guid256Converter class and tagged Guid256
- supports Dictionaries with Guid256 as Keys and Values
- Added xunit tests
- minor namespace cleanup


## [0.1.1-alpha] - 2025-02-25
### Added
- Initial release of Guid256 package.
- Implemented `Guid256` class for 256-bit GUIDs.
- Added static method `Guid256.NewGuid256()` for generating new 256-bit GUIDs.
- created github and nuget package

## Usage

```csharp

// Generate a new Guid256
Guid256 id = Guid256.NewGuid256();

//Hex output
string hexString = id.ToString();
Guid256 id2 = Guid256.Parse(hexString);
```
## Installation

You can install Guid256 via NuGet:

```sh
dotnet add package Utils.Guid256 -IncludePrerelease
```

```sh
Install-Package Utils.Guid256 -IncludePrerelease
```

## Benchamarks
```sh
BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


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
```