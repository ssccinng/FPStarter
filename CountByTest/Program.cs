// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Test>();

[MemoryDiagnoser]
[ShortRunJob]
public class Test
{
    public int[] Seq;
[GlobalSetup]
    public void SetUp()
    {
        Seq =Enumerable.Range(0, 10000).Select(s => Random.Shared.Next()).ToArray();
    }
    
    [Benchmark]
    public Dictionary<int, int> Grouping() => Seq.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    
    [Benchmark]
    public Dictionary<int, int> LookUp() => Seq.ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());
    [Benchmark(Baseline = true)]
    
    public Dictionary<int, int> Counting() => Seq.CountBy(x => x).ToDictionary(x => x.Key, x => x.Value);
    
}