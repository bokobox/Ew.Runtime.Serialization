using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class UIntFormatter : BinaryFormatter<uint>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (uint) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, uint value)
        {
            const int size = sizeof(uint);
            writer.Append(value, size).Size(size);
        }

        public override uint Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<uint>(size);
        }
    }
}