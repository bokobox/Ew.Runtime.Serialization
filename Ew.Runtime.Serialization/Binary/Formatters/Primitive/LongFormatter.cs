using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class LongFormatter : BinaryFormatter<long>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (long) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, long value)
        {
            const int size = sizeof(long);
            writer.Append(value, size).Size(size);
        }

        public override long Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<long>(size);
        }
    }
}