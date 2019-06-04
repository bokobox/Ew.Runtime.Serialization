using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class BoolFormatter : BinaryFormatter<bool>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (bool) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, bool value)
        {
            writer.Append(value ? (byte) 1 : (byte) 0).Size(sizeof(byte));
        }

        public override bool Deserialize(ref BinaryBufferReader reader)
        {
            reader.Size();
            return reader.Data() == 1;
        }
    }
}