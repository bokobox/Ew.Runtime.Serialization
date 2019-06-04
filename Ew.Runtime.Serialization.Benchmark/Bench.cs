using BenchmarkDotNet.Attributes;
using MessagePack;

namespace Ew.Runtime.Serialization.Benchmark
{
    public class Bench
    {
        private readonly TestModel _model = new TestModel();

        public Bench()
        {
            var bin1 = MessagePackSerializer.Serialize(_model);
            var bin2 = BinarySerializer.Serialize(_model);
            var model1 = MessagePackSerializer.Deserialize<TestModel>(bin1);
            var model2 = BinarySerializer.Deserialize<TestModel>(bin2);
        }

        [Benchmark]
        public void EwSerializer()
        {
            var bin = BinarySerializer.Serialize(_model);
            var model = BinarySerializer.Deserialize<TestModel>(bin);
        }

        [Benchmark]
        public void MessagePack()
        {
            var bin = MessagePackSerializer.Serialize(_model);
            var model = MessagePackSerializer.Deserialize<TestModel>(bin);
        }
    }
}