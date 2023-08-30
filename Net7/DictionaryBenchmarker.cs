using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;
using System.Linq;

namespace Net7;

[MemoryDiagnoser]
public class DictionaryBenchmarker
{
    private const int _numberOfItems = 1_000;
    private static readonly Dictionary<Guid, string> _dict = new();
    private static readonly ImmutableDictionary<Guid, string> _immutableDict;
    private static readonly Guid _searchKey = new("14b1ba7c-c0d8-406c-8ca6-030e8ebc223a");

    static DictionaryBenchmarker()
    {
        _dict.Add(_searchKey, _searchKey.ToString());

        for (int i = 0; i < _numberOfItems - 1; i++)
        {
            var key = Guid.NewGuid();
            _dict.Add(key, key.ToString());
        }

        _immutableDict = _dict.ToImmutableDictionary();
    }


    [Benchmark]
    public void CreateDictionary()
    {
        _ = _dict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }


    [Benchmark]
    public void CreateImmutableDictionary()
    {
        _ = _dict.ToImmutableDictionary();
    }


    [Benchmark]
    public string ReadDictionary()
    {
        return _dict[_searchKey];
    }


    [Benchmark]
    public string ReadImmutableDictionary()
    {
        return _immutableDict[_searchKey];
    }
}