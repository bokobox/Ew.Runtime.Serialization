using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ByteFormatter : BinaryFormatter<byte>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (byte) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, byte value)
        {
            writer.Append(value).Size(sizeof(byte));
        }

        public override byte Deserialize(ref BinaryBufferReader reader)
        {
            reader.Size();
            return reader.Data();
        }
    }
}