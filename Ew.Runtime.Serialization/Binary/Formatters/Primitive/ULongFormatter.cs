using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ULongFormatter : BinaryFormatter<ulong>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (ulong) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, ulong value)
        {
            const int size = sizeof(ulong);
            writer.Append(value, size).Size(size);
        }

        public override ulong Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<ulong>(size);
        }
    }
}