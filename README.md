# Guid256

Guid256 is a lightweight .NET package that provides a custom implementation for working with 256-bit GUIDs. It offers seamless serialization support and easy conversion between standard GUIDs and 256-bit GUIDs. It uses System.Security.Cryptography.RandomNumberGenerator to create Random bits.

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

- 
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
