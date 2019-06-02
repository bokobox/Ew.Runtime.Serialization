using BenchmarkDotNet.Attributes;
using MessagePack;

namespace Ew.Runtime.Serialization.Benchmark
{
    public class Bench
    {
        private readonly TestModel _model = new TestModel();
        
        [Benchmark]
        public void MessagePack()
        {
            var bin = MessagePackSerializer.Serialize(_model);
        }
        
        [Benchmark]
        public void EwSerializer()
        {
            var bin = BinarySerializer.Serialize(_model);
        }
    }
}