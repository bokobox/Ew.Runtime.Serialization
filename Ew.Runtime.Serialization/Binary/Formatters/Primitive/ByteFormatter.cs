using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ByteFormatter : IBinaryFormatable<byte>
    {
        public void Serialize(ref InternalBufferWriter writer, byte value)
        {
            var bin = new[] {value};
            writer.Append(bin).Size(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (byte)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public byte Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data(size)[0];
        }
    }
}