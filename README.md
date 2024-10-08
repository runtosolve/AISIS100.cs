# AISIS100.cs

This is an unofficial .NET API for AISIS100 Specification (American Iron and Steel Institute Specification for the Design of Cold-Formed Steel Structural Members).
Each equation in AISIS100 is converted into a method in the API. Open-source and free to use (MIT License).

Seamlessly integrate AISIS100 design checks into your .NET application without having to writing down the equations yourself.

Each API generates a detailed output that includes all the intermediate calculations and the final result with references to specific sections in the Specification.

Whether you are developing full-fledged cold-formed steel (CFS) design software or just want to automate some of your CFS design workflows, this package can help you to get started quickly.

## Installation
Install the package from NuGet
```bash
nuget install AISIS100.cs
```

Install the package from dotnet CLI
```bash
dotnet add package AISIS100.cs
```

## Usage
The architecture of the API is an exact replica of the AISIS100 Specification.
Each chapter in the specification is a class in the API. 
Within each class, each equation is a method.
For example, to calculate the nominal distortional buckling strength of a section under compression by Direct Strength Method (DSM), 
you need to use Eq.F4-1 and Eq.F4-2 in Chapter F4 of the AISIS100 Specification.
Instead of writing down the equations yourself, you can use the API to do the calculation for you.

```csharp
var Mnd = AISIS100.ChapterFFlexure.EqF4__2(Mcrd, My, output);
```

The `output` parameter is an instance of `Output` class that contains the intermediate calculations and the final result with references to the Specification.
You can use `GetResult(string key)` method retrieve the all the intermediate results and look up the references in the Specification.
