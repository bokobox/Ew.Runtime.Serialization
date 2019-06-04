using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ULongFormatter : BinaryFormatter<ulong>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (ulong) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, ulong value)
        {
            const int size = sizeof(ulong);
            writer.Append(value, size).Size(size);
        }

        public override ulong Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<ulong>(size);
        }
    }
}