using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class LongFormatter : BinaryFormatter<long>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (long) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, long value)
        {
            const int size = sizeof(long);
            writer.Append(value, size).Size(size);
        }

        public override long Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<long>(size);
        }
    }
}