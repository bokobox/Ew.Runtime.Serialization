using BenchmarkDotNet.Running;
using MessagePack;

namespace Ew.Runtime.Serialization.Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var model = new TestModel();

            var bin1 = MessagePackSerializer.Serialize("あいうえお");
            var bin2 = BinarySerializer.Serialize("あいうえお");
            var model1 = MessagePackSerializer.Deserialize<TestModel>(bin1);
            var model2 = BinarySerializer.Deserialize<TestModel>(bin2);
            //BenchmarkRunner.Run<Bench>();
        }
    }
}