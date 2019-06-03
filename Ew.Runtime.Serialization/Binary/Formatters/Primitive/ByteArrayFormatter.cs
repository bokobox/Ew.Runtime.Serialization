using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ByteArrayFormatter : BinaryFormatter<byte[]>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (byte[]) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, byte[] value)
        {
            if (value == null || value.Length == 0)
                writer.Size(0);
            else
                writer.Append(value).Size(value.Length);
        }

        public override byte[] Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return size == 0 ? null : reader.Data(size);
        }
    }
}