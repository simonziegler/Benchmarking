// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Net8;

var summary = BenchmarkRunner.Run<DictionaryBenchmarker>();