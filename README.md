# CodeCleanser

A tool whose purpose is to transform C# code generated from a DLL so that it can then be determined if two DLLs are semantically identical.

## Usage

Run `CodeCleanser` on each directory you wish to compare and fire up your favorite compare tool afterward - `CodeCleanser` will also explore sub directories.

```
CodeCleanser <directory-path>
```

This tool has been built around a single use case. The code was decompiled using [dotPeek][dot-peek] and I only needed to remove the comments at the top of the files and sort the [Attributes][attributes-link] by alphabetical order.

This project is harnessing the power of [Roslyn][roslyn-link].

[dot-peek]: https://www.jetbrains.com/decompiler/
[attributes-link]: https://msdn.microsoft.com/en-us/library/mt653979.aspx
[roslyn-link]: https://github.com/dotnet/roslyn