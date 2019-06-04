using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ByteArrayFormatter : BinaryFormatter<byte[]>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (byte[]) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, byte[] value)
        {
            if (value == null || value.Length == 0)
                writer.Size(0);
            else
                writer.Append(value).Size(value.Length);
        }

        public override byte[] Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return size == 0 ? null : reader.Data(size);
        }
    }
}