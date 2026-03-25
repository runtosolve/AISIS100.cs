# AISIS100.cs

*AISI S100 cold-formed steel design equations, implemented as a .NET library.*

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/AISIS100.cs.svg)](https://www.nuget.org/packages/AISIS100.cs)
[![.NET](https://img.shields.io/badge/.NET-6.0%2B-512BD4?logo=dotnet)](https://dotnet.microsoft.com)
[![Docs](https://img.shields.io/badge/docs-available-brightgreen)](https://runtosolve.github.io/AISIS100.cs/)

---

## The Problem

Cold-formed steel design is still largely implemented in spreadsheets. Each project requires
re-creating AISI S100 equations — often in workbooks that are difficult to audit, extend, or
reuse, with limited transparency into how results are produced.

---

## What It Does

`AISIS100.cs` implements the **AISI S100 North American Specification for the Design of
Cold-Formed Steel Structural Members** as a .NET class library.

- Covers tension, compression, flexure, shear, combined loading, connections, and distortional buckling
- Returns both **nominal strength** and **available strength** (ASD, LRFD, LSD)
- Includes an `Output` object that captures intermediate calculations and specification references at every step

Three editions are currently supported:

| Edition                   | Design Methods  |
|---------------------------|-----------------|
| AISI S100-16              | ASD, LRFD, LSD  |
| AISI S100-16 Supplement 3 | ASD, LRFD, LSD  |
| AISI S100-24              | ASD, LRFD, LSD  |

---

## Installation

**NuGet Package Manager:**
```
Install-Package AISIS100.cs
```

**.NET CLI:**
```
dotnet add package AISIS100.cs
```

---

## Quick Start

```csharp
using AISIS100;

var output = new Output();

double My   = 50.0;  // kip-in, yield moment
double Mcrd = 28.0;  // kip-in, critical elastic distortional buckling moment

double Mnd  = ChapterFFlexure.DistortionalBucklingStrengthMnd(My, Mcrd, output);
double aMnd = ChapterFFlexure.AvailableDistortionalBucklingStrengthMnd(Mnd, "LRFD", output);

Console.WriteLine($"Nominal:          {Mnd:F2} kip-in");
Console.WriteLine($"Available (LRFD): {aMnd:F2} kip-in");
```

```
Nominal:          31.26 kip-in
Available (LRFD): 28.13 kip-in
```

---

## Documentation

Full API reference: [runtosolve.github.io/AISIS100.cs](https://runtosolve.github.io/AISIS100.cs)

---

## License

This project is licensed under the [MIT License](LICENSE).
