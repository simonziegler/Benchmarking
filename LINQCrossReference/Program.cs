// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using LINQCrossReference;

var summary = BenchmarkRunner.Run<LINQBenchmarker>();