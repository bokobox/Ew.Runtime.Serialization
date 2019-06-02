using System;
using BenchmarkDotNet.Running;

namespace Ew.Runtime.Serialization.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
        }
    }
}