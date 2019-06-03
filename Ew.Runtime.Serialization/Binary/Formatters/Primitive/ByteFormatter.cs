using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ByteFormatter : BinaryFormatter<byte>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (byte) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, byte value)
        {
            writer.Append(value).Size(sizeof(byte));
        }

        public override byte Deserialize(ref InternalBufferReader reader)
        {
            reader.Size();
            return reader.Data();
        }
    }
}