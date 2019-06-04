using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class UShortFormatter : BinaryFormatter<ushort>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (ushort) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, ushort value)
        {
            const int size = sizeof(ushort);
            writer.Append(value, size).Size(size);
        }

        public override ushort Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<ushort>(size);
        }
    }
}