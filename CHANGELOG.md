# Changelog

## [v0.3.0-alpha] - 2025-02-28
### soon

- benchamrk options added
- minor performance improvements
- AsReadOnlySpan<byte>() added
- changed/improved Equals/==
- some code cleanup
- updated construction under the hood, less byte copying (specifically using RandomNumberGenerator.Fill(...) instead of ...GetBytes(...))

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

### Fixed
- Initial implementation, no fixes at this stage.

### Changed
- Initial implementation, no changes at this stage.

### Removed
- Initial implementation, no removals at this stage.
