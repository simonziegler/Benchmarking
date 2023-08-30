# C# .NET 7 and .NET 8 dictionary benchmarking

This repository contains a benchmarking project for comparing the performance of the .NET 7 and .NET 8 dictionary 
implementations. In each case the dictionary is populated with 1,000 items keyed by a `GUID`. The dictionaries under test
are `Dictionary<TKey, TValue>`,  `ImmutableDictionary<TKey, TValue>`. and `FozenDictionary<TKey, TValue>` (.NET 8 only).

## .NET 7 results, 30 August 2023

|                    Method |           Mean |         Error |        StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------- |---------------:|--------------:|--------------:|-------:|-------:|----------:|
|          CreateDictionary |  31,240.272 ns |   525.2366 ns |   465.6086 ns | 3.1738 | 0.3662 |   39904 B |
| CreateImmutableDictionary | 288,476.598 ns | 1,818.2316 ns | 1,700.7750 ns | 5.3711 | 0.9766 |   72104 B |
|            ReadDictionary |       4.329 ns |     0.0783 ns |     0.0653 ns |      - |      - |         - |
|   ReadImmutableDictionary |      18.132 ns |     0.1645 ns |     0.1539 ns |      - |      - |         - |

## .NET 8 preview 7 results, 30 August 2023

|                    Method |           Mean |         Error |        StdDev |         Median |   Gen0 |   Gen1 | Allocated |
|-------------------------- |---------------:|--------------:|--------------:|---------------:|-------:|-------:|----------:|
|          CreateDictionary |   7,746.038 ns |    87.9983 ns |    82.3136 ns |   7,774.612 ns | 3.1586 |      - |   39840 B |
| CreateImmutableDictionary | 188,891.925 ns | 3,762.2349 ns | 7,513.5895 ns | 187,970.239 ns | 5.6152 | 1.2207 |   72104 B |
|    CreateFrozenDictionary |  24,844.395 ns |   493.2556 ns | 1,051.1678 ns |  24,375.867 ns | 7.3242 |      - |   92360 B |
|            ReadDictionary |       5.547 ns |     0.0534 ns |     0.0446 ns |       5.560 ns |      - |      - |         - |
|   ReadImmutableDictionary |       9.637 ns |     0.2278 ns |     0.2532 ns |       9.535 ns |      - |      - |         - |
|      ReadFrozenDictionary |       3.474 ns |     0.1018 ns |     0.0902 ns |       3.453 ns |      - |      - |         - |