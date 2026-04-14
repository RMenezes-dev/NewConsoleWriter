# Changelog

All notable changes to this project will be documented in this file.

The format is based on Keep a Changelog,
and this project adheres to Semantic Versioning.

## [Unreleased]

---

## [1.1.0] - 2026-04-14

### Added
- Fixed-width console headers with support for:
  - Foreground and background colors
  - Text transformations
  - Automatic text wrapping and alignment
- New WriteHeader overloads for flexible usage.

### Improved
- Balanced text distribution across multiple header lines.
- Handling of long words using recursive splitting.
- Improved readability of headers for multi-line content.

---

## [1.0.0] - 2026-01-19

### Added
- Core methods for writing colored text to the console.
- Support for foreground and background colors.
- Semantic methods:
  - WriteSuccess
  - WriteWarning
  - WriteError
  - WriteInfo
- Optional text transformations:
  - UpperCase
  - LowerCase
  - TitleCase
- Automatic restoration of console colors after writing.