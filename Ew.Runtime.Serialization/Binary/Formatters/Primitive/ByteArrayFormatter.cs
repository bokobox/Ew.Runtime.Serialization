using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ByteArrayFormatter  : IBinaryFormatable<byte[]>
    {
        public void Serialize(ref InternalBufferWriter writer, byte[] value)
        {
            if (value == null || value.Length == 0)
                return;
            
            writer.Append(value).Append(value.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (byte[])value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public byte[] Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data(size);
        }
    }
}