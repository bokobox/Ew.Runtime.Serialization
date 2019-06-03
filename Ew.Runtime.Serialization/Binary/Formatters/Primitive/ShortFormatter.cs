using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ShortFormatter : BinaryFormatter<short>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (short) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, short value)
        {
            const int size = sizeof(short);
            writer.Append(value, size).Size(size);
        }

        public override short Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<short>(size);
        }
    }
}