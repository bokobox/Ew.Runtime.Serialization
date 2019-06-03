using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class BoolFormatter : BinaryFormatter<bool>, IDynamicBinaryFormatable
    {
        public override void Serialize(ref InternalBufferWriter writer, bool value)
        {
            writer.Append(value ? (byte) 1 : (byte) 0).Size(sizeof(byte));
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (bool)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override bool Deserialize(ref InternalBufferReader reader)
        {
            reader.Size();
            return reader.Data() == 1;
        }
    }
}