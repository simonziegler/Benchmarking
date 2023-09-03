using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;
using System.Linq;

namespace LINQCrossReference;

[MemoryDiagnoser]
public class LINQBenchmarker
{
    private const int _numberOfParents = 1_000;
    private const int _numberOfChildrenPerParent = 10;
    private static readonly Dictionary<Guid, ParentClass> parents = new();
    private static readonly Dictionary<Guid, ChildClass> children = new();

    static LINQBenchmarker()
    {
        for (int p = 0; p < _numberOfParents; p++)
        {
            var parent = new ParentClass
            {
                Id = Guid.NewGuid(),
                Name = $"Parent {p:N0}"
            };

            parents.Add(parent.Id, parent);

            for (int c = 0; c < _numberOfChildrenPerParent; c++)
            {
                var child = new ChildClass
                {
                    Id = Guid.NewGuid(),
                    Name = $"Child {c:N0} of parent {p:N0}",
                    Parent = parent,
                    ParentId = parent.Id
                };

                children.Add(child.Id, child);
            }
        }
    }


    [Benchmark]
    public void IndirectReference()
    {
        _ = (from c in children.Values
             from p in parents
             where p.Key == c.ParentId
             select new JoinedDataClass
             {
                 ChildId = c.Id,
                 ChildName = c.Name,
                 ParentId = c.ParentId,
                 ParentName = p.Value.Name
             })
            .ToArray();
    }


    [Benchmark]
    public void ParentValueJoin()
    {
        _ = (from c in children.Values
             join p in parents.Values on c.ParentId equals p.Id
             select new JoinedDataClass
             {
                 ChildId = c.Id,
                 ChildName = c.Name,
                 ParentId = c.ParentId,
                 ParentName = p.Name
             })
            .ToArray();
    }


    [Benchmark]
    public void ParentKeyJoin()
    {
        _ = (from c in children.Values
             join p in parents on c.ParentId equals p.Key
             select new JoinedDataClass
             {
                 ChildId = c.Id,
                 ChildName = c.Name,
                 ParentId = c.ParentId,
                 ParentName = p.Value.Name
             })
            .ToArray();
    }


    [Benchmark]
    public void KeyedDictionaryLookup()
    {
        _ = children.Values
            .Select(c => new JoinedDataClass
            {
                ChildId = c.Id,
                ChildName = c.Name,
                ParentId = c.ParentId,
                ParentName = parents[c.ParentId].Name
            })
            .ToArray();
    }


    [Benchmark]
    public void EmbeddedReference()
    {
        _ = children.Values
            .Select(c => new JoinedDataClass
            {
                ChildId = c.Id,
                ChildName = c.Name,
                ParentId = c.ParentId,
                ParentName = c.Parent.Name
            })
            .ToArray();
    }
}