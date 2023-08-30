// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Net8;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<DictionaryBenchmarker>();