using BenchmarkDotNet.Running;

namespace Ew.Runtime.Serialization.Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
        }
    }
}