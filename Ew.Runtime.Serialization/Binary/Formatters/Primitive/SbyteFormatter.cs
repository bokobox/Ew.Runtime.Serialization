using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class SbyteFormatter : BinaryFormatter<sbyte>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (sbyte) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, sbyte value)
        {
            const int size = sizeof(sbyte);
            writer.Append(value, size).Size(size);
        }

        public override sbyte Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<sbyte>(size);
        }
    }
}