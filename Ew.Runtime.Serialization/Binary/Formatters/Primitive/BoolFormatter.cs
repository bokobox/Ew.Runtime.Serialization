using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class BoolFormatter : IBinaryFormatable<bool>
    {
        public void Serialize(ref InternalBufferWriter writer, bool value)
        {
            const int size = sizeof(byte);
            writer.Append(value ? (byte) 1 : (byte) 0).Size(size);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (bool)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public bool Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data() == 1;
        }
    }
}